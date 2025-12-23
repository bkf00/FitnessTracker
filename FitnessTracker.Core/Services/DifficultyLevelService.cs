using FitnessTracker.Core.Dtos.DifficultyLevel;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;

namespace FitnessTracker.Core.Services;

public sealed class DifficultyLevelService : IDifficultyLevelService
{
    private readonly IDifficultyLevelRepository _repository;

    public DifficultyLevelService(IDifficultyLevelRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<DifficultyLevelDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(DifficultyLevelMapper.ToDto).ToList();
    }
}
