using FitnessTracker.Core.Dtos.WorkoutExercise;

namespace FitnessTracker.Core.Services;

public interface IWorkoutExerciseService
{
    Task<WorkoutExerciseDto?> GetByIdAsync(int id);
    Task<WorkoutExerciseDto> CreateAsync(CreateWorkoutExerciseRequest request);
    Task<WorkoutExerciseDto?> UpdateAsync(int id, UpdateWorkoutExerciseRequest request);
}
