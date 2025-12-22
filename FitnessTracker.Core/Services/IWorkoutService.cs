using FitnessTracker.Core.Dtos.Workout;

namespace FitnessTracker.Core.Services;

public interface IWorkoutService
{
    Task<WorkoutDto?> GetByIdAsync(int id);
    Task<WorkoutDto> CreateAsync(CreateWorkoutRequest request);
    Task<WorkoutDto?> UpdateAsync(int id, UpdateWorkoutRequest request);
}
