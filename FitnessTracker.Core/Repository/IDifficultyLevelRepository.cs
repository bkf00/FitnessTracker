using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IDifficultyLevelRepository
{
    Task<IReadOnlyList<DifficultyLevel>> GetAllAsync();
    Task<bool> ExistsAsync(string value);
}
