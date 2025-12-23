using FitnessTracker.Core.Dtos.Goal;
using FitnessTracker.Core.Exceptions;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class GoalService : IGoalService
{
    private readonly IGoalRepository _goalRepository;
    private readonly IUserRepository _userRepository;

    public GoalService(
        IGoalRepository goalRepository,
        IUserRepository userRepository)
    {
        _goalRepository = goalRepository;
        _userRepository = userRepository;
    }

    public async Task<GoalDto?> GetByIdAsync(int id)
    {
        var goal = await _goalRepository.GetByIdAsync(id);
        return goal is null ? null : GoalMapper.ToDto(goal);
    }

    public async Task<GoalDto> CreateAsync(CreateGoalRequest request)
    {
        // 🔹 1. Overlap check (trg_Goal_NoOverlap)
        bool hasOverlap = await _goalRepository.HasOverlappingGoalAsync(
            request.UserId,
            request.GoalType,
            request.StartDate,
            request.EndDate);

        if (hasOverlap)
            throw new BusinessRuleException(
                "Overlapping goals of the same type are not allowed.");

        // 🔹 2. Weight logic (trg_Goal_WeightLogic)
        var currentWeight = await _userRepository.GetCurrentWeightAsync(request.UserId);
        if (!currentWeight.HasValue)
            throw new BusinessRuleException("User not found.");

        if (request.GoalType == "weight_loss" &&
            request.TargetValue >= currentWeight.Value)
            throw new BusinessRuleException(
                "Weight-loss goal must target less than current weight.");

        if (request.GoalType == "weight_gain" &&
            request.TargetValue <= currentWeight.Value)
            throw new BusinessRuleException(
                "Weight-gain goal must target more than current weight.");

        // 🔹 3. Create & save
        var goal = new Goal(
            request.UserId,
            request.GoalType,
            request.TargetValue,
            request.StartDate,
            request.EndDate);

        await _goalRepository.AddAsync(goal);
        return GoalMapper.ToDto(goal);
    }

    public async Task<GoalDto?> UpdateAsync(int id, UpdateGoalRequest request)
    {
        var goal = await _goalRepository.GetByIdAsync(id);
        if (goal is null) return null;

        // 🔹 1. Overlap check (exclude current goal)
        bool hasOverlap = await _goalRepository.HasOverlappingGoalAsync(
            goal.UserId,
            goal.GoalType,
            goal.StartDate,
            request.EndDate,
            excludeGoalId: goal.Id);

        if (hasOverlap)
            throw new BusinessRuleException(
                "Overlapping goals of the same type are not allowed.");

        // 🔹 2. Weight logic
        var currentWeight = await _userRepository.GetCurrentWeightAsync(goal.UserId);
        if (!currentWeight.HasValue)
            throw new BusinessRuleException("User not found.");

        if (goal.GoalType == "weight_loss" &&
            request.TargetValue >= currentWeight.Value)
            throw new BusinessRuleException(
                "Weight-loss goal must target less than current weight.");

        if (goal.GoalType == "weight_gain" &&
            request.TargetValue <= currentWeight.Value)
            throw new BusinessRuleException(
                "Weight-gain goal must target more than current weight.");

        // 🔹 3. Apply update
        goal.UpdateTarget(request.TargetValue, request.EndDate);
        await _goalRepository.UpdateAsync(goal);

        return GoalMapper.ToDto(goal);
    }
}
