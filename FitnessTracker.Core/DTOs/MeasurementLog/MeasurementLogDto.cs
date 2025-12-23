namespace FitnessTracker.Core.Dtos.MeasurementLog;

public sealed class MeasurementLogDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public DateOnly MeasurementDate { get; init; }
    public decimal Weight { get; init; }
    public decimal BodyFatPercentage { get; init; }
    public decimal WaistCircumference { get; init; }
    public decimal ChestCircumference { get; init; }
    public decimal ArmCircumference { get; init; }
}
