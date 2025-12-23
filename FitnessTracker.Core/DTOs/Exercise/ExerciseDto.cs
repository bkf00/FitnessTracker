namespace FitnessTracker.Core.Dtos.Exercise;

public sealed class ExerciseDto
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string MuscleGroup { get; init; } = default!;
    public string DifficultyLevel { get; init; } = default!;
}
