using FitnessTracker.Core.Dtos.WorkoutExercise;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repositories;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class WorkoutExerciseService : IWorkoutExerciseService
{
    private readonly IWorkoutExerciseRepository _repository;

    public WorkoutExerciseService(IWorkoutExerciseRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkoutExerciseDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : WorkoutExerciseMapper.ToDto(entity);
    }

    public async Task<WorkoutExerciseDto> CreateAsync(CreateWorkoutExerciseRequest request)
    {
        var entity = new WorkoutExercise(
            request.WorkoutId,
            request.ExerciseId,
            request.Sets,
            request.Reps,
            request.WeightUsed
        );

        await _repository.AddAsync(entity);
        return WorkoutExerciseMapper.ToDto(entity);
    }

    public async Task<WorkoutExerciseDto?> UpdateAsync(int id, UpdateWorkoutExerciseRequest request)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return null;

        entity.Update(request.Sets, request.Reps, request.WeightUsed);
        await _repository.UpdateAsync(entity);

        return WorkoutExerciseMapper.ToDto(entity);
    }
}
