using FitnessTracker.Core.Dtos.FoodLog;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IFoodLogService
{
    Task<FoodLogDto?> GetByIdAsync(int id);
    Task<FoodLogDto> CreateAsync(CreateFoodLogRequest request);
    Task<FoodLogDto?> UpdateAsync(int id, UpdateFoodLogRequest request);
}
