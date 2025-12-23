using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IWorkoutExerciseRepository
{
    Task<WorkoutExercise?> GetByIdAsync(int id);
    Task<IReadOnlyList<WorkoutExercise>> GetAllAsync();
    Task<IReadOnlyList<WorkoutExercise>> GetAllByWorkoutAsync(int workoutId);
    Task AddAsync(WorkoutExercise workoutExercise);
    Task<bool> UpdateAsync(WorkoutExercise workoutExercise);
    Task<bool> ExistsAsync(int workoutId, int exerciseId);
    Task<bool> DeleteAsync(int id);
}
