using FitnessTracker.Core.Dtos.Goal;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class GoalMapper
{
    public static GoalDto ToDto(Goal goal) => new()
    {
        Id = goal.Id,
        UserId = goal.UserId,
        GoalType = goal.GoalType,
        TargetValue = goal.TargetValue,
        StartDate = goal.StartDate,
        EndDate = goal.EndDate,
        IsAchieved = goal.IsAchieved
    };
}
