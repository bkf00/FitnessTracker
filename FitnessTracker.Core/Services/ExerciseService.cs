using FitnessTracker.Core.Dtos.Exercise;
using FitnessTracker.Core.Exceptions;
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

    public ExerciseService(
        IExerciseRepository exerciseRepository,
        IMuscleGroupRepository muscleGroupRepository,
        IDifficultyLevelRepository difficultyLevelRepository)
    {
        _repository = exerciseRepository;
        _muscleGroupRepository = muscleGroupRepository;
        _difficultyLevelRepository = difficultyLevelRepository;
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
            throw new BusinessRuleException("Invalid muscle group.");

        if (!await _difficultyLevelRepository.ExistsAsync(request.DifficultyLevel))
            throw new BusinessRuleException("Invalid difficulty level.");

        if (await _repository.ExistsByNameAsync(request.Name))
            throw new BusinessRuleException(
                "An exercise with the same name already exists.");


        var exercise = new Exercise(
            request.Name,
            request.MuscleGroup,
            request.DifficultyLevel
        );

        await _repository.AddAsync(exercise);
        return ExerciseMapper.ToDto(exercise);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        if (await _repository.IsUsedInWorkoutsAsync(id))
            throw new BusinessRuleException(
                "Exercise cannot be deleted because it is used in workouts.");

        return await _repository.DeleteAsync(id);
    }

}