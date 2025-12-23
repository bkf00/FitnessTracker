using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repositories;

public interface IMuscleGroupRepository
{
    Task<IReadOnlyList<MuscleGroup>> GetAllAsync();
    Task<bool> ExistsAsync(string value);
}
