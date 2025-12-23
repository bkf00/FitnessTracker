namespace FitnessTracker.Domain.Entities;

public class Exercise
{
    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string MuscleGroup { get; private set; } = default!;
    public string DifficultyLevel { get; private set; } = default!;

    private Exercise() { }

    public Exercise(string name, string muscleGroup, string difficultyLevel)
    {
        Name = name;
        MuscleGroup = muscleGroup;
        DifficultyLevel = difficultyLevel;
    }

    public void SetId(int id)
    {
        Id = id;
    }
}
