using FitnessTracker.Core.Dtos.Exercise;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _repository;
    private readonly IMuscleGroupRepository _muscleGroupRepository;
    private readonly IDifficultyLevelRepository _difficultyLevelRepository;

    public ExerciseService(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExerciseDto?> GetByIdAsync(int id)
    {
        var exercise = await _repository.GetByIdAsync(id);
        return exercise is null ? null : ExerciseMapper.ToDto(exercise);
    }

    public async Task<IReadOnlyList<ExerciseDto>> GetAllAsync()
    {
        var exercises = await _repository.GetAllAsync();
        return exercises.Select(ExerciseMapper.ToDto).ToList();
    }

    public async Task<ExerciseDto> CreateAsync(CreateExerciseRequest request)
    {
        if (!await _muscleGroupRepository.ExistsAsync(request.MuscleGroup))
            throw new InvalidOperationException("Invalid muscle group.");

        if (!await _difficultyLevelRepository.ExistsAsync(request.DifficultyLevel))
            throw new InvalidOperationException("Invalid difficulty level.");

        var exercise = new Exercise(
            request.Name,
            request.MuscleGroup,
            request.DifficultyLevel
        );

        await _repository.AddAsync(exercise);
        return ExerciseMapper.ToDto(exercise);
    }
}
