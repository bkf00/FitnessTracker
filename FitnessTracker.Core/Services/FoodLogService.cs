using FitnessTracker.Core.Dtos.FoodLog;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class FoodLogService : IFoodLogService
{
    private readonly IFoodLogRepository _repository;

    public FoodLogService(IFoodLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<FoodLogDto?> GetByIdAsync(int id)
    {
        var log = await _repository.GetByIdAsync(id);
        return log is null ? null : FoodLogMapper.ToDto(log);
    }

    public async Task<FoodLogDto> CreateAsync(CreateFoodLogRequest request)
    {
        var log = new FoodLog(
            request.UserId,
            request.FoodItemId,
            request.LogDate,
            request.Servings,
            request.Quantity
        );

        await _repository.AddAsync(log);
        return FoodLogMapper.ToDto(log);
    }

    public async Task<FoodLogDto?> UpdateAsync(int id, UpdateFoodLogRequest request)
    {
        var log = await _repository.GetByIdAsync(id);
        if (log is null) return null;

        log.Update(request.Servings, request.Quantity);
        await _repository.UpdateAsync(log);

        return FoodLogMapper.ToDto(log);
    }
}
