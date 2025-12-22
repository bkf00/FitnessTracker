namespace FitnessTracker.Core.Dtos.WorkoutExercise;

public sealed class CreateWorkoutExerciseRequest
{
    public int WorkoutId { get; init; }
    public int ExerciseId { get; init; }
    public int Sets { get; init; }
    public int Reps { get; init; }
    public decimal? WeightUsed { get; init; }
}
