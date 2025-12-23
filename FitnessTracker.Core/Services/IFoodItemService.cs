using FitnessTracker.Core.Dtos.FoodItem;

namespace FitnessTracker.Core.Services;

public interface IFoodItemService
{
    Task<IReadOnlyList<FoodItemDto>> GetAllAsync();
    Task<FoodItemDto?> GetByIdAsync(int id);
    Task<FoodItemDto> CreateAsync(CreateFoodItemRequest request);
}
