using FitnessTracker.Core.Repository;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainExercise = FitnessTracker.Domain.Entities.Exercise;
using EfExercise = FitnessTracker.Infrastructure.Models.Exercise;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class ExerciseRepository : IExerciseRepository
{
    private readonly FitnessDbContext _context;

    public ExerciseRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<DomainExercise?> GetByIdAsync(int id)
    {
        EfExercise? entity = await _context.Exercises
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task<IReadOnlyList<DomainExercise>> GetAllAsync()
    {
        var entities = await _context.Exercises
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();

        return entities.Select(MapToDomain).ToList();
    }

    public async Task AddAsync(DomainExercise exercise)
    {
        EfExercise entity = MapToEntity(exercise);
        _context.Exercises.Add(entity);
        await _context.SaveChangesAsync();

        exercise.SetId(entity.Id);
    }
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Exercises
            .AsNoTracking()
            .AnyAsync(e => e.Name.ToLower() == name.ToLower());
    }

    public async Task<bool> IsUsedInWorkoutsAsync(int exerciseId)
    {
        return await _context.WorkoutExercises
            .AsNoTracking()
            .AnyAsync(we => we.ExerciseId == exerciseId);
    }

    public async Task<bool> ExistsAsync(int exerciseId)
    {
        return await _context.Exercises
            .AsNoTracking()
            .AnyAsync(e => e.Id == exerciseId);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Exercises.FindAsync(id);
        if (entity is null) return false;

        _context.Exercises.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }


    private static DomainExercise MapToDomain(EfExercise entity)
    {
        var exercise = new DomainExercise(
            entity.Name,
            entity.MuscleGroup,
            entity.DifficultyLevel
        );

        exercise.SetId(entity.Id);
        return exercise;
    }

    private static EfExercise MapToEntity(DomainExercise domain)
        => new()
        {
            Name = domain.Name,
            MuscleGroup = domain.MuscleGroup,
            DifficultyLevel = domain.DifficultyLevel
        };
}
