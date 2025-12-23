using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IFoodItemRepository
{
    Task<FoodItem?> GetByIdAsync(int id);
    Task<IReadOnlyList<FoodItem>> GetAllAsync();
    Task AddAsync(FoodItem foodItem);
    Task<bool> ExistsByNameAsync(string name);

    // TODO: admin update food item
    // Task<bool> UpdateAsync(FoodItem foodItem);

}
