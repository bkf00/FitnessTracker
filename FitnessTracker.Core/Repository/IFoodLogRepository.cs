using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IFoodLogRepository
{
    Task<FoodLog?> GetByIdAsync(int id);
    Task AddAsync(FoodLog foodLog);
    Task<bool> UpdateAsync(FoodLog foodLog);
}
