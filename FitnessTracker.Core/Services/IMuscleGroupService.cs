using FitnessTracker.Core.Dtos.MuscleGroup;

namespace FitnessTracker.Core.Services;

public interface IMuscleGroupService
{
    Task<IReadOnlyList<MuscleGroupDto>> GetAllAsync();
}
