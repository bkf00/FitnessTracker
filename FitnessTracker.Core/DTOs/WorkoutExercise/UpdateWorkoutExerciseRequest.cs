namespace FitnessTracker.Core.Dtos.WorkoutExercise;

public sealed class UpdateWorkoutExerciseRequest
{
    public int Sets { get; init; }
    public int Reps { get; init; }
    public decimal? WeightUsed { get; init; }
}
