using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IWorkoutRepository
{
    Task<IReadOnlyList<Workout>> GetAllAsync();
    Task<IReadOnlyList<Workout>> GetAllByUserAsync(int userId);
    Task<Workout?> GetByIdAsync(int id);
    Task AddAsync(Workout workout);
    Task<bool> ExistsAsync(int workoutId);
    Task<bool> UpdateAsync(Workout workout);
    Task<bool> DeleteAsync(int id);
}
