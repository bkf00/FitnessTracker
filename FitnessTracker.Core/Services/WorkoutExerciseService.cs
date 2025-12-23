using FitnessTracker.Core.Dtos.WorkoutExercise;
using FitnessTracker.Core.Exceptions;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class WorkoutExerciseService : IWorkoutExerciseService
{
    private readonly IWorkoutExerciseRepository _repository;
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public WorkoutExerciseService(
        IWorkoutExerciseRepository repository,
        IWorkoutRepository workoutRepository,
        IExerciseRepository exerciseRepository)
    {
        _repository = repository;
        _workoutRepository = workoutRepository;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<WorkoutExerciseDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : WorkoutExerciseMapper.ToDto(entity);
    }

    public async Task<WorkoutExerciseDto> CreateAsync(CreateWorkoutExerciseRequest request)
    {
        if (await _repository.ExistsAsync(request.WorkoutId, request.ExerciseId))
            throw new BusinessRuleException(
                "This exercise is already added to the workout.");

        if (!await _workoutRepository.ExistsAsync(request.WorkoutId))
            throw new BusinessRuleException("Workout does not exist.");
        
        if (!await _exerciseRepository.ExistsAsync(request.ExerciseId))
            throw new BusinessRuleException("Exercise does not exist.");


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
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;

        var workout = await _workoutRepository.GetByIdAsync(entity.WorkoutId);
        if (workout is null)
            throw new BusinessRuleException("Workout does not exist.");

        if (workout.StartAt.AddMinutes(workout.DurationInMinutes) < DateTime.UtcNow)
            throw new BusinessRuleException(
                "Cannot delete exercises from a completed workout.");

        return await _repository.DeleteAsync(id);
    }



}
