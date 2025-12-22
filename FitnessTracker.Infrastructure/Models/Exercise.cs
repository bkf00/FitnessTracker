using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string MuscleGroup { get; set; } = null!;

    public string DifficultyLevel { get; set; } = null!;

    public virtual DifficultyLevel DifficultyLevelNavigation { get; set; } = null!;

    public virtual MuscleGroup MuscleGroupNavigation { get; set; } = null!;

    public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}
