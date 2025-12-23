namespace FitnessTracker.Domain.Entities;

public class DifficultyLevel
{
    public string Value { get; private set; } = default!;

    private DifficultyLevel() { }

    public DifficultyLevel(string value)
    {
        Value = value;
    }
}
