using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repositories;

public interface IMeasurementLogRepository
{
    Task<MeasurementLog?> GetLastByUserAsync(int userId);
    Task AddAsync(MeasurementLog log);
}
