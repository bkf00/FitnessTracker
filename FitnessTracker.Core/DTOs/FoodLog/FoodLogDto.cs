namespace FitnessTracker.Core.Dtos.FoodLog;

public sealed class FoodLogDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public int FoodItemId { get; init; }
    public DateOnly LogDate { get; init; }
    public decimal Servings { get; init; }
    public decimal Quantity { get; init; }
}
