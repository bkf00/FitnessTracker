namespace FitnessTracker.Core.Dtos.FoodLog;

public sealed class CreateFoodLogRequest
{
    public int UserId { get; init; }
    public int FoodItemId { get; init; }
    public DateOnly LogDate { get; init; }
    public decimal Servings { get; init; }
    public decimal Quantity { get; init; }
}
