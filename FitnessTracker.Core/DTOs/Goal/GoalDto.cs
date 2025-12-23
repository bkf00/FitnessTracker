namespace FitnessTracker.Core.Dtos.Goal;

public sealed class GoalDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public string GoalType { get; init; } = default!;
    public decimal TargetValue { get; init; }
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public bool IsAchieved { get; init; }
}
