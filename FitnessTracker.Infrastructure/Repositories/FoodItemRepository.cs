using FitnessTracker.Core.Repository;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainFoodItem = FitnessTracker.Domain.Entities.FoodItem;
using EfFoodItem = FitnessTracker.Infrastructure.Models.FoodItem;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class FoodItemRepository : IFoodItemRepository
{
    private readonly FitnessDbContext _context;

    public FoodItemRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<DomainFoodItem?> GetByIdAsync(int id)
    {
        EfFoodItem? entity = await _context.FoodItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task<IReadOnlyList<DomainFoodItem>> GetAllAsync()
    {
        var entities = await _context.FoodItems
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();

        return entities.Select(MapToDomain).ToList();
    }

    public async Task AddAsync(DomainFoodItem foodItem)
    {
        EfFoodItem entity = MapToEntity(foodItem);
        _context.FoodItems.Add(entity);
        await _context.SaveChangesAsync();

        foodItem.SetId(entity.Id);
    }

    public async Task<bool> UpdateAsync(DomainFoodItem foodItem)
    {
        EfFoodItem? entity = await _context.FoodItems.FindAsync(foodItem.Id);
        if (entity is null) return false;

        entity.Calories = foodItem.Calories;
        entity.Protein = foodItem.Protein;
        entity.Carbs = foodItem.Carbs;
        entity.Fat = foodItem.Fat;

        await _context.SaveChangesAsync();
        return true;
    }

    private static DomainFoodItem MapToDomain(EfFoodItem entity)
    {
        var item = new DomainFoodItem(
            entity.Name,
            entity.Calories,
            entity.Protein,
            entity.Carbs,
            entity.Fat);

        item.SetId(entity.Id);
        return item;
    }

    private static EfFoodItem MapToEntity(DomainFoodItem domain)
        => new()
        {
            Name = domain.Name,
            Calories = domain.Calories,
            Protein = domain.Protein,
            Carbs = domain.Carbs,
            Fat = domain.Fat
        };
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.FoodItems
            .AsNoTracking()
            .AnyAsync(x => x.Name == name);
    }

}
