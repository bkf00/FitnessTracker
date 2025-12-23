using FitnessTracker.Core.Dtos.Exercise;

namespace FitnessTracker.Core.Services;

public interface IExerciseService
{
    Task<ExerciseDto?> GetByIdAsync(int id);
    Task<IReadOnlyList<ExerciseDto>> GetAllAsync();
    Task<ExerciseDto> CreateAsync(CreateExerciseRequest request);
}
