using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repositories;

public interface IFoodItemRepository
{
    Task<FoodItem?> GetByIdAsync(int id);
    Task<IReadOnlyList<FoodItem>> GetAllAsync();
    Task AddAsync(FoodItem foodItem);

    // TODO: admin update food item
    // Task<bool> UpdateAsync(FoodItem foodItem);
}
