using FitnessTracker.Core.Dtos.MuscleGroup;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IMuscleGroupService
{
    Task<IReadOnlyList<MuscleGroupDto>> GetAllAsync();
}
