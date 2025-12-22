namespace FitnessTracker.Domain.Entities;

public class Workout
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public DateTime StartAt { get; private set; }
    public int DurationInMinutes { get; private set; }
    public string? Notes { get; private set; }

    private Workout() { }

    public Workout(int userId, DateTime startAt, int durationInMinutes, string? notes)
    {
        UserId = userId;
        StartAt = startAt;
        DurationInMinutes = durationInMinutes;
        Notes = notes;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Update(int durationInMinutes, string? notes)
    {
        DurationInMinutes = durationInMinutes;
        Notes = notes;
    }
}
