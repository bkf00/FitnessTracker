namespace FitnessTracker.Core.Dtos.Goal;

public sealed class UpdateGoalRequest
{
    public decimal TargetValue { get; init; }
    public DateOnly EndDate { get; init; }
}
