using System;
using System.Collections.Generic;

namespace FitnessTracker.Data.ScaffoldModels;

public partial class FoodItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Calories { get; set; }

    public decimal Protein { get; set; }

    public decimal Carbs { get; set; }

    public decimal Fat { get; set; }

    public virtual ICollection<FoodLog> FoodLogs { get; set; } = new List<FoodLog>();
}
