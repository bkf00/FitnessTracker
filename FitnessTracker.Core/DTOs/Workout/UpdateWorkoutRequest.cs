namespace FitnessTracker.Core.Dtos.Workout;

public sealed class UpdateWorkoutRequest
{
    public int DurationInMinutes { get; init; }
    public string? Notes { get; init; }
}
