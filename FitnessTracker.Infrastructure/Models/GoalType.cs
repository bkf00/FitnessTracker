using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class GoalType
{
    public string Value { get; set; } = null!;

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();
}
