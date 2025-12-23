using FitnessTracker.Core.Dtos.Exercise;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class ExerciseMapper
{
    public static ExerciseDto ToDto(Exercise entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        MuscleGroup = entity.MuscleGroup,
        DifficultyLevel = entity.DifficultyLevel
    };
}
