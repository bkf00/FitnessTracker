using FitnessTracker.Core.Dtos.Workout;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IWorkoutService
{
    Task<IReadOnlyList<WorkoutDto>> GetAllAsync();
    Task<IReadOnlyList<WorkoutDto>> GetAllByUserAsync(int userId);
    Task<WorkoutDto?> GetByIdAsync(int id);
    Task<WorkoutDto> CreateAsync(CreateWorkoutRequest request);
    Task<WorkoutDto?> UpdateAsync(int id, UpdateWorkoutRequest request);
    Task<bool> DeleteAsync(int id);
}
