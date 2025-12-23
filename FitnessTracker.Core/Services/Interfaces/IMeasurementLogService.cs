using FitnessTracker.Core.Dtos.MeasurementLog;

namespace FitnessTracker.Core.Services.Interfaces;

public interface IMeasurementLogService
{
    Task<MeasurementLogDto> CreateAsync(CreateMeasurementLogRequest request);
}
