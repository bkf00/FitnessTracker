using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repositories;

public interface IWorkoutRepository
{
    Task<Workout?> GetByIdAsync(int id);
    Task AddAsync(Workout workout);
    Task<bool> UpdateAsync(Workout workout);
}
