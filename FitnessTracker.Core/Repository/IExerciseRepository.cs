using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(int id);
    Task<IReadOnlyList<Exercise>> GetAllAsync();
    Task AddAsync(Exercise exercise);
}
