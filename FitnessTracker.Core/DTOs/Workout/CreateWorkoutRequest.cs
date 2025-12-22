namespace FitnessTracker.Core.Dtos.Workout;

public sealed class CreateWorkoutRequest
{
    public int UserId { get; init; }
    public DateTime StartAt { get; init; }
    public int DurationInMinutes { get; init; }
    public string? Notes { get; init; }
}
