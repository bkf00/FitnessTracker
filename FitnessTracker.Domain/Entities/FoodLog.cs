namespace FitnessTracker.Domain.Entities;

public class FoodLog
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int FoodItemId { get; private set; }
    public DateOnly LogDate { get; private set; }
    public decimal Servings { get; private set; }
    public decimal Quantity { get; private set; }

    private FoodLog() { }
    public FoodLog(
        int userId,
        int foodItemId,
        DateOnly logDate,
        decimal servings,
        decimal quantity)
    {
        UserId = userId;
        FoodItemId = foodItemId;
        LogDate = logDate;
        Servings = servings;
        Quantity = quantity;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Update(decimal servings, decimal quantity)
    {
        Servings = servings;
        Quantity = quantity;
    }
}
