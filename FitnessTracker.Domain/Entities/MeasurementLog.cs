namespace FitnessTracker.Domain.Entities;

public class MeasurementLog
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public DateOnly MeasurementDate { get; private set; }
    public decimal Weight { get; private set; }
    public decimal BodyFatPercentage { get; private set; }
    public decimal WaistCircumference { get; private set; }
    public decimal ChestCircumference { get; private set; }
    public decimal ArmCircumference { get; private set; }

    private MeasurementLog() { }

    public MeasurementLog(
        int userId,
        DateOnly measurementDate,
        decimal weight,
        decimal bodyFatPercentage,
        decimal waistCircumference,
        decimal chestCircumference,
        decimal armCircumference)
    {
        UserId = userId;
        MeasurementDate = measurementDate;
        Weight = weight;
        BodyFatPercentage = bodyFatPercentage;
        WaistCircumference = waistCircumference;
        ChestCircumference = chestCircumference;
        ArmCircumference = armCircumference;
    }

    public void SetId(int id)
    {
        Id = id;
    }
}
