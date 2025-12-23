using FitnessTracker.Core.Dtos.MeasurementLog;
using FluentValidation;

namespace FitnessTracker.Api.Validators.MeasurementLog;

public sealed class CreateMeasurementLogRequestValidator
    : AbstractValidator<CreateMeasurementLogRequest>
{
    public CreateMeasurementLogRequestValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.MeasurementDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));

        RuleFor(x => x.Weight)
            .GreaterThan(0)
            .LessThanOrEqualTo(500);

        RuleFor(x => x.BodyFatPercentage)
            .InclusiveBetween(2, 60);

        RuleFor(x => x.WaistCircumference)
            .GreaterThan(20)
            .LessThanOrEqualTo(250);

        RuleFor(x => x.ChestCircumference)
            .GreaterThan(20)
            .LessThanOrEqualTo(250);

        RuleFor(x => x.ArmCircumference)
            .GreaterThan(10)
            .LessThanOrEqualTo(100);
    }
}
