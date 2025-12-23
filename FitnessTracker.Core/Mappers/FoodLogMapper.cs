using FitnessTracker.Core.Dtos.FoodLog;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class FoodLogMapper
{
    public static FoodLogDto ToDto(FoodLog entity) => new()
    {
        Id = entity.Id,
        UserId = entity.UserId,
        FoodItemId = entity.FoodItemId,
        LogDate = entity.LogDate,
        Servings = entity.Servings,
        Quantity = entity.Quantity
    };
}
