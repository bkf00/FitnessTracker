using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repositories;

public interface IWorkoutExerciseRepository
{
    Task<WorkoutExercise?> GetByIdAsync(int id);
    Task AddAsync(WorkoutExercise workoutExercise);
    Task<bool> UpdateAsync(WorkoutExercise workoutExercise);
}
