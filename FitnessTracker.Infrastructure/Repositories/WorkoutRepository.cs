using FitnessTracker.Core.Repository;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainWorkout = FitnessTracker.Domain.Entities.Workout;
using EfWorkout = FitnessTracker.Infrastructure.Models.Workout;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class WorkoutRepository : IWorkoutRepository
{
    private readonly FitnessDbContext _context;

    public WorkoutRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<DomainWorkout?> GetByIdAsync(int id)
    {
        EfWorkout? entity = await _context.Workouts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(DomainWorkout workout)
    {
        EfWorkout entity = MapToEntity(workout);
        _context.Workouts.Add(entity);
        await _context.SaveChangesAsync();

        workout.SetId(entity.Id);
    }

    public async Task<bool> UpdateAsync(DomainWorkout workout)
    {
        EfWorkout? entity = await _context.Workouts.FindAsync(workout.Id);
        if (entity is null) return false;

        entity.DurationInMinutes = workout.DurationInMinutes;
        entity.Notes = workout.Notes;

        await _context.SaveChangesAsync();
        return true;
    }

    private static DomainWorkout MapToDomain(EfWorkout entity)
    {
        var workout = new DomainWorkout(
            entity.UserId,
            entity.StartAt,
            entity.DurationInMinutes,
            entity.Notes
        );

        workout.SetId(entity.Id);
        return workout;
    }

    private static EfWorkout MapToEntity(DomainWorkout domain)
        => new()
        {
            UserId = domain.UserId,
            StartAt = domain.StartAt,
            DurationInMinutes = domain.DurationInMinutes,
            Notes = domain.Notes
        };
}
