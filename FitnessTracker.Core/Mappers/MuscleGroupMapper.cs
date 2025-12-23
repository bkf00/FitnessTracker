using FitnessTracker.Core.Dtos.MuscleGroup;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class MuscleGroupMapper
{
    public static MuscleGroupDto ToDto(MuscleGroup entity) => new()
    {
        Value = entity.Value
    };
}
