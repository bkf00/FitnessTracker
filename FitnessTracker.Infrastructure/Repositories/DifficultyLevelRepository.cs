using FitnessTracker.Core.Repositories;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainDifficultyLevel = FitnessTracker.Domain.Entities.DifficultyLevel;
using EfDifficultyLevel = FitnessTracker.Infrastructure.Models.DifficultyLevel;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class DifficultyLevelRepository : IDifficultyLevelRepository
{
    private readonly FitnessDbContext _context;

    public DifficultyLevelRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<DomainDifficultyLevel>> GetAllAsync()
    {
        var entities = await _context.DifficultyLevels
            .AsNoTracking()
            .OrderBy(x => x.Value)
            .ToListAsync();

        return entities
            .Select(e => new DomainDifficultyLevel(e.Value))
            .ToList();
    }

    public async Task<bool> ExistsAsync(string value)
    {
        return await _context.DifficultyLevels
            .AsNoTracking()
            .AnyAsync(x => x.Value == value);
    }
}
