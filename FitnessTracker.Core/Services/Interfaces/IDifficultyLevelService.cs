using FitnessTracker.Core.Dtos.DifficultyLevel;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IDifficultyLevelService
{
    Task<IReadOnlyList<DifficultyLevelDto>> GetAllAsync();
}
