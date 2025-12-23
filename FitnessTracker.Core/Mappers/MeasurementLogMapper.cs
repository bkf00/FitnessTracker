using FitnessTracker.Core.Dtos.MeasurementLog;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class MeasurementLogMapper
{
    public static MeasurementLogDto ToDto(MeasurementLog log) => new()
    {
        Id = log.Id,
        UserId = log.UserId,
        MeasurementDate = log.MeasurementDate,
        Weight = log.Weight,
        BodyFatPercentage = log.BodyFatPercentage,
        WaistCircumference = log.WaistCircumference,
        ChestCircumference = log.ChestCircumference,
        ArmCircumference = log.ArmCircumference
    };
}
