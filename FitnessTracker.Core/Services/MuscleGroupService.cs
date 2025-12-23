using FitnessTracker.Core.Dtos.MuscleGroup;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repositories;

namespace FitnessTracker.Core.Services;

public sealed class MuscleGroupService : IMuscleGroupService
{
    private readonly IMuscleGroupRepository _repository;

    public MuscleGroupService(IMuscleGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<MuscleGroupDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(MuscleGroupMapper.ToDto).ToList();
    }
}
