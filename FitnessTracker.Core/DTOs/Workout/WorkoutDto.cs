namespace FitnessTracker.Core.Dtos.Workout;

public sealed class WorkoutDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public DateTime StartAt { get; init; }
    public int DurationInMinutes { get; init; }
    public string? Notes { get; init; }
}
