namespace FitnessTracker.Core.Dtos.FoodLog;

public sealed class UpdateFoodLogRequest
{
    public decimal Servings { get; init; }
    public decimal Quantity { get; init; }
}
