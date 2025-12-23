using FitnessTracker.Core.Repository;
using FitnessTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using DomainMeasurementLog = FitnessTracker.Domain.Entities.MeasurementLog;
using EfMeasurementLog = FitnessTracker.Infrastructure.Models.MeasurementLog;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class MeasurementLogRepository : IMeasurementLogRepository
{
    private readonly FitnessDbContext _context;

    public MeasurementLogRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<DomainMeasurementLog?> GetLastByUserAsync(int userId)
    {
        EfMeasurementLog? entity = await _context.MeasurementLogs
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.MeasurementDate)
            .FirstOrDefaultAsync();

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(DomainMeasurementLog log)
    {
        EfMeasurementLog entity = MapToEntity(log);
        _context.MeasurementLogs.Add(entity);
        await _context.SaveChangesAsync();

        log.SetId(entity.Id);
    }

    private static DomainMeasurementLog MapToDomain(EfMeasurementLog entity)
    {
        var log = new DomainMeasurementLog(
            entity.UserId,
            entity.MeasurementDate,
            entity.Weight,
            entity.BodyFatPercentage,
            entity.WaistCircumference,
            entity.ChestCircumference,
            entity.ArmCircumference
        );

        log.SetId(entity.Id);
        return log;
    }

    private static EfMeasurementLog MapToEntity(DomainMeasurementLog domain)
        => new()
        {
            UserId = domain.UserId,
            MeasurementDate = domain.MeasurementDate,
            Weight = domain.Weight,
            BodyFatPercentage = domain.BodyFatPercentage,
            WaistCircumference = domain.WaistCircumference,
            ChestCircumference = domain.ChestCircumference,
            ArmCircumference = domain.ArmCircumference
        };
}
