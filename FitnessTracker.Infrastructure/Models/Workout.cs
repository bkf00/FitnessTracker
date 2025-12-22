using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class Workout
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime StartAt { get; set; }

    public int DurationInMinutes { get; set; }

    public string? Notes { get; set; }

    public DateTime? StartAtMinute { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}
