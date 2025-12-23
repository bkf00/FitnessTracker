using FitnessTracker.Core.Repositories;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainFoodLog = FitnessTracker.Domain.Entities.FoodLog;
using EfFoodLog = FitnessTracker.Infrastructure.Models.FoodLog;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class FoodLogRepository : IFoodLogRepository
{
    private readonly FitnessDbContext _context;

    public FoodLogRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<DomainFoodLog?> GetByIdAsync(int id)
    {
        EfFoodLog? entity = await _context.FoodLogs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(DomainFoodLog foodLog)
    {
        EfFoodLog entity = MapToEntity(foodLog);
        _context.FoodLogs.Add(entity);
        await _context.SaveChangesAsync();

        foodLog.SetId(entity.Id);
    }

    public async Task<bool> UpdateAsync(DomainFoodLog foodLog)
    {
        EfFoodLog? entity = await _context.FoodLogs.FindAsync(foodLog.Id);
        if (entity is null) return false;

        entity.Servings = foodLog.Servings;
        entity.Quantity = foodLog.Quantity;

        await _context.SaveChangesAsync();
        return true;
    }

    private static DomainFoodLog MapToDomain(EfFoodLog entity)
    {
        var log = new DomainFoodLog(
            entity.UserId,
            entity.FoodItemId,
            entity.LogDate,
            entity.Servings,
            entity.Quantity
        );

        log.SetId(entity.Id);
        return log;
    }

    private static EfFoodLog MapToEntity(DomainFoodLog domain)
        => new()
        {
            UserId = domain.UserId,
            FoodItemId = domain.FoodItemId,
            LogDate = domain.LogDate,
            Servings = domain.Servings,
            Quantity = domain.Quantity
        };
}
