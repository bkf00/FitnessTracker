using FitnessTracker.Core.Dtos.Goal;

namespace FitnessTracker.Core.Services;

public interface IGoalService
{
    Task<GoalDto?> GetByIdAsync(int id);
    Task<GoalDto> CreateAsync(CreateGoalRequest request);
    Task<GoalDto?> UpdateAsync(int id, UpdateGoalRequest request);
}
