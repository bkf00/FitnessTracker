using FitnessTracker.Core.Dtos.Goal;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IGoalService
{
    Task<GoalDto?> GetByIdAsync(int id);
    Task<GoalDto> CreateAsync(CreateGoalRequest request);
    Task<GoalDto?> UpdateAsync(int id, UpdateGoalRequest request);
}
