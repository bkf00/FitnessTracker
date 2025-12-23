namespace FitnessTracker.Domain.Entities;

public class FoodItem
{
    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public int Calories { get; private set; }
    public decimal Protein { get; private set; }
    public decimal Carbs { get; private set; }
    public decimal Fat { get; private set; }

    private FoodItem() { }

    public FoodItem(
        string name,
        int calories,
        decimal protein,
        decimal carbs,
        decimal fat)
    {
        Name = name;
        Calories = calories;
        Protein = protein;
        Carbs = carbs;
        Fat = fat;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void UpdateMacros(
        int calories,
        decimal protein,
        decimal carbs,
        decimal fat)
    {
        Calories = calories;
        Protein = protein;
        Carbs = carbs;
        Fat = fat;
    }
}
