namespace FitnessTracker.Domain.Entities;

public class Goal
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string GoalType { get; private set; } = default!;
    public decimal TargetValue { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public bool IsAchieved { get; private set; }

    private Goal() { }

    public Goal(
        int userId,
        string goalType,
        decimal targetValue,
        DateOnly startDate,
        DateOnly endDate)
    {
        UserId = userId;
        GoalType = goalType;
        TargetValue = targetValue;
        StartDate = startDate;
        EndDate = endDate;
        IsAchieved = false;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void MarkAchieved()
    {
        IsAchieved = true;
    }

    public void UpdateTarget(decimal targetValue, DateOnly endDate)
    {
        TargetValue = targetValue;
        EndDate = endDate;
    }
}
