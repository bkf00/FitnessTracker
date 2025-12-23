namespace FitnessTracker.Domain.Entities;

public class MuscleGroup
{
    public string Value { get; private set; } = default!;

    private MuscleGroup() { }

    public MuscleGroup(string value)
    {
        Value = value;
    }
}
