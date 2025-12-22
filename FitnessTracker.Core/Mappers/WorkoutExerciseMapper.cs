using FitnessTracker.Core.Dtos.WorkoutExercise;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class WorkoutExerciseMapper
{
    public static WorkoutExerciseDto ToDto(WorkoutExercise entity) => new()
    {
        Id = entity.Id,
        WorkoutId = entity.WorkoutId,
        ExerciseId = entity.ExerciseId,
        Sets = entity.Sets,
        Reps = entity.Reps,
        WeightUsed = entity.WeightUsed
    };
}
