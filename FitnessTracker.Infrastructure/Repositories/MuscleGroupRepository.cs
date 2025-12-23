using FitnessTracker.Core.Repository;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainMuscleGroup = FitnessTracker.Domain.Entities.MuscleGroup;
using EfMuscleGroup = FitnessTracker.Infrastructure.Models.MuscleGroup;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class MuscleGroupRepository : IMuscleGroupRepository
{
    private readonly FitnessDbContext _context;

    public MuscleGroupRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<DomainMuscleGroup>> GetAllAsync()
    {
        var entities = await _context.MuscleGroups
            .AsNoTracking()
            .OrderBy(x => x.Value)
            .ToListAsync();

        return entities.Select(e => new DomainMuscleGroup(e.Value)).ToList();
    }

    public async Task<bool> ExistsAsync(string value)
    {
        return await _context.MuscleGroups
            .AsNoTracking()
            .AnyAsync(x => x.Value == value);
    }
}
