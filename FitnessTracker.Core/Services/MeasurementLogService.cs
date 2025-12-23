using FitnessTracker.Core.Dtos.MeasurementLog;
using FitnessTracker.Core.Exceptions;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public sealed class MeasurementLogService : IMeasurementLogService
{
    private const decimal MaxDailyWeightDeltaKg = 2.0m;

    private readonly IMeasurementLogRepository _repository;
    private readonly IUserRepository _userRepository;

    public MeasurementLogService(
        IMeasurementLogRepository repository,
        IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<MeasurementLogDto> CreateAsync(CreateMeasurementLogRequest request)
    {
        var registrationDate = await _userRepository.GetRegistrationDateAsync(request.UserId);
        if (!registrationDate.HasValue)
            throw new BusinessRuleException("User not found.");

        if (request.MeasurementDate < registrationDate.Value)
            throw new BusinessRuleException(
                "Measurement date cannot be before user registration date.");

        var lastLog = await _repository.GetLastByUserAsync(request.UserId);

        if (lastLog is not null)
        {
            var days =
                (request.MeasurementDate.ToDateTime(TimeOnly.MinValue)
                - lastLog.MeasurementDate.ToDateTime(TimeOnly.MinValue)).Days;

            if (days > 0)
            {
                var dailyDelta =
                    Math.Abs(request.Weight - lastLog.Weight) / days;

                if (dailyDelta > MaxDailyWeightDeltaKg)
                    throw new BusinessRuleException(
                        $"Weight change exceeds {MaxDailyWeightDeltaKg} kg per day.");
            }
        }

        var log = new MeasurementLog(
            request.UserId,
            request.MeasurementDate,
            request.Weight,
            request.BodyFatPercentage,
            request.WaistCircumference,
            request.ChestCircumference,
            request.ArmCircumference
        );

        await _repository.AddAsync(log);
        return MeasurementLogMapper.ToDto(log);
    }
}
