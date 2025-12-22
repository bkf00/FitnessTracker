using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class Goal
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string GoalType { get; set; } = null!;

    public decimal TargetValue { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsAchieved { get; set; }

    public virtual GoalType GoalTypeNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
