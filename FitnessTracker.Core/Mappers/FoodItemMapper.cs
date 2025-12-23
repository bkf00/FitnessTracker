using FitnessTracker.Core.Dtos.FoodItem;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class FoodItemMapper
{
    public static FoodItemDto ToDto(FoodItem entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Calories = entity.Calories,
        Protein = entity.Protein,
        Carbs = entity.Carbs,
        Fat = entity.Fat
    };
}
