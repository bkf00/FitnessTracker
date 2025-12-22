namespace FitnessTracker.Domain.Entities;

public class WorkoutExercise
{
    public int Id { get; private set; }
    public int WorkoutId { get; private set; }
    public int ExerciseId { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }
    public decimal? WeightUsed { get; private set; }

    private WorkoutExercise() { }

    public WorkoutExercise(
        int workoutId,
        int exerciseId,
        int sets,
        int reps,
        decimal? weightUsed)
    {
        WorkoutId = workoutId;
        ExerciseId = exerciseId;
        Sets = sets;
        Reps = reps;
        WeightUsed = weightUsed;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Update(int sets, int reps, decimal? weightUsed)
    {
        Sets = sets;
        Reps = reps;
        WeightUsed = weightUsed;
    }
}
