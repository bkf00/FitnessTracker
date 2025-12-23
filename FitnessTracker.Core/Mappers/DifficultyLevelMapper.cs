using FitnessTracker.Core.Dtos.DifficultyLevel;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class DifficultyLevelMapper
{
    public static DifficultyLevelDto ToDto(DifficultyLevel entity) => new()
    {
        Value = entity.Value
    };
}
