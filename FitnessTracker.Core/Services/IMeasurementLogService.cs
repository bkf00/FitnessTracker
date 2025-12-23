using FitnessTracker.Core.Dtos.MeasurementLog;

namespace FitnessTracker.Core.Services;

public interface IMeasurementLogService
{
    Task<MeasurementLogDto> CreateAsync(CreateMeasurementLogRequest request);
}
