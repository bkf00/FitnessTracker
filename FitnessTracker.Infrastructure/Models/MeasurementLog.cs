using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class MeasurementLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly MeasurementDate { get; set; }

    public decimal Weight { get; set; }

    public decimal BodyFatPercentage { get; set; }

    public decimal WaistCircumference { get; set; }

    public decimal ChestCircumference { get; set; }

    public decimal ArmCircumference { get; set; }

    public virtual User User { get; set; } = null!;
}
