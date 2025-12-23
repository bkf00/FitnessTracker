using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IGoalRepository
{
    Task<Goal?> GetByIdAsync(int id);
    Task AddAsync(Goal goal);
    Task<bool> UpdateAsync(Goal goal);
    Task<bool> HasOverlappingGoalAsync(
        int userId,
        string goalType,
        DateOnly startDate,
        DateOnly endDate,
        int? excludeGoalId = null);
}
