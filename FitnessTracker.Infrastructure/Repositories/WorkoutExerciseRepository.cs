using FitnessTracker.Core.Repository;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainWorkoutExercise = FitnessTracker.Domain.Entities.WorkoutExercise;
using EfWorkoutExercise = FitnessTracker.Infrastructure.Models.WorkoutExercise;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class WorkoutExerciseRepository : IWorkoutExerciseRepository
{
    private readonly FitnessDbContext _context;

    public WorkoutExerciseRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<DomainWorkoutExercise?> GetByIdAsync(int id)
    {
        EfWorkoutExercise? entity = await _context.WorkoutExercises
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(DomainWorkoutExercise workoutExercise)
    {
        EfWorkoutExercise entity = MapToEntity(workoutExercise);
        _context.WorkoutExercises.Add(entity);
        await _context.SaveChangesAsync();

        workoutExercise.SetId(entity.Id);
    }

    public async Task<bool> UpdateAsync(DomainWorkoutExercise workoutExercise)
    {
        EfWorkoutExercise? entity = await _context.WorkoutExercises
            .FindAsync(workoutExercise.Id);

        if (entity is null) return false;

        entity.Sets = workoutExercise.Sets;
        entity.Reps = workoutExercise.Reps;
        entity.WeightUsed = workoutExercise.WeightUsed;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int workoutId, int exerciseId)
    {
        return await _context.WorkoutExercises
            .AsNoTracking()
            .AnyAsync(x =>
                x.WorkoutId == workoutId &&
                x.ExerciseId == exerciseId);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.WorkoutExercises.FindAsync(id);
        if (entity is null) return false;

        _context.WorkoutExercises.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }


    private static DomainWorkoutExercise MapToDomain(EfWorkoutExercise entity)
    {
        var workoutExercise = new DomainWorkoutExercise(
            entity.WorkoutId,
            entity.ExerciseId,
            entity.Sets,
            entity.Reps,
            entity.WeightUsed
        );

        workoutExercise.SetId(entity.Id);
        return workoutExercise;
    }

    private static EfWorkoutExercise MapToEntity(DomainWorkoutExercise domain)
        => new()
        {
            WorkoutId = domain.WorkoutId,
            ExerciseId = domain.ExerciseId,
            Sets = domain.Sets,
            Reps = domain.Reps,
            WeightUsed = domain.WeightUsed
        };
}
