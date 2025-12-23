namespace FitnessTracker.Core.Dtos.FoodItem;

public sealed class CreateFoodItemRequest
{
    public string Name { get; init; } = default!;
    public int Calories { get; init; }
    public decimal Protein { get; init; }
    public decimal Carbs { get; init; }
    public decimal Fat { get; init; }
}
