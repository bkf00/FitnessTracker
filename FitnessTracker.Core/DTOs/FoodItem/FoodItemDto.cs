namespace FitnessTracker.Core.Dtos.FoodItem;

public sealed class FoodItemDto
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public int Calories { get; init; }
    public decimal Protein { get; init; }
    public decimal Carbs { get; init; }
    public decimal Fat { get; init; }
}
