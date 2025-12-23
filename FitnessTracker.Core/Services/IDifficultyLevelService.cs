using FitnessTracker.Core.Dtos.DifficultyLevel;

namespace FitnessTracker.Core.Services;

public interface IDifficultyLevelService
{
    Task<IReadOnlyList<DifficultyLevelDto>> GetAllAsync();
}
