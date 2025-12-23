using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(int id);
    Task<IReadOnlyList<Exercise>> GetAllAsync();
    Task AddAsync(Exercise exercise);
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> IsUsedInWorkoutsAsync(int exerciseId);
    Task<bool> ExistsAsync(int exerciseId);
    Task<bool> DeleteAsync(int id);
}
