using FitnessTracker.Core.Dtos.Workout;
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

    public async Task<WorkoutDto?> GetByIdAsync(int id)
    {
        var workout = await _repository.GetByIdAsync(id);
        return workout is null ? null : WorkoutMapper.ToDto(workout);
    }

    public async Task<WorkoutDto> CreateAsync(CreateWorkoutRequest request)
    {
        var workout = new Workout(
            request.UserId,
            request.StartAt,
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
}
