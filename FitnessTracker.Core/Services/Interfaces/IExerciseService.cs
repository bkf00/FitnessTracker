using FitnessTracker.Core.Dtos.Exercise;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IExerciseService
{
    Task<ExerciseDto?> GetByIdAsync(int id);
    Task<IReadOnlyList<ExerciseDto>> GetAllAsync();
    Task<ExerciseDto> CreateAsync(CreateExerciseRequest request);
    Task<bool> DeleteAsync(int id);
}
