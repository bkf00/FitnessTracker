using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class MuscleGroup
{
    public string Value { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
