using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class FoodLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FoodItemId { get; set; }

    public DateOnly LogDate { get; set; }

    public decimal Servings { get; set; }

    public decimal Quantity { get; set; }

    public virtual FoodItem FoodItem { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
