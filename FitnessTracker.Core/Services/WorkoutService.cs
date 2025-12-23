using FitnessTracker.Core.Dtos.Workout;
using FitnessTracker.Core.Exceptions;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _repository;

    public WorkoutService(IWorkoutRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<WorkoutDto>> GetAllAsync()
    {
        var workouts = await _repository.GetAllAsync();
        return workouts.Select(WorkoutMapper.ToDto).ToList();
    }

    public async Task<IReadOnlyList<WorkoutDto>> GetAllByUserAsync(int userId)
    {
        var workouts = await _repository.GetAllByUserAsync(userId);
        return workouts.Select(WorkoutMapper.ToDto).ToList();
    }

    public async Task<WorkoutDto?> GetByIdAsync(int id)
    {
        var workout = await _repository.GetByIdAsync(id);
        return workout is null ? null : WorkoutMapper.ToDto(workout);
    }

    public async Task<WorkoutDto> CreateAsync(CreateWorkoutRequest request)
    {
        var normalizedStartAt = new DateTime(
            request.StartAt.Year,
            request.StartAt.Month,
            request.StartAt.Day,
            request.StartAt.Hour,
            request.StartAt.Minute,
            0,
            DateTimeKind.Utc);

        if (request.StartAt.Second != 0 || request.StartAt.Millisecond != 0)
            throw new BusinessRuleException(
                "Workout start time must be rounded to the minute.");

        if (request.DurationInMinutes <= 0)
            throw new BusinessRuleException(
                "Workout duration must be positive.");

        var workoutEndAt = normalizedStartAt.AddMinutes(request.DurationInMinutes);

        if (workoutEndAt > DateTime.UtcNow)
            throw new BusinessRuleException(
                "Workout cannot end in the future.");

        var workout = new Workout(
            request.UserId,
            normalizedStartAt,
            request.DurationInMinutes,
            request.Notes
        );

        await _repository.AddAsync(workout);
        return WorkoutMapper.ToDto(workout);
    }


    public async Task<WorkoutDto?> UpdateAsync(int id, UpdateWorkoutRequest request)
    {
        var workout = await _repository.GetByIdAsync(id);
        if (workout is null) return null;

        workout.Update(request.DurationInMinutes, request.Notes);
        await _repository.UpdateAsync(workout);

        return WorkoutMapper.ToDto(workout);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
