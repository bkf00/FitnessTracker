namespace FitnessTracker.Core.Dtos.Goal;

public sealed class CreateGoalRequest
{
    public int UserId { get; init; }
    public string GoalType { get; init; } = default!;
    public decimal TargetValue { get; init; }
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
}
