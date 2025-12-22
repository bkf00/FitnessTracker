using FitnessTracker.Core.Dtos.Workout;
using FluentValidation;

namespace FitnessTracker.Api.Validators.Workout;

public sealed class CreateWorkoutRequestValidator
    : AbstractValidator<CreateWorkoutRequest>
{
    public CreateWorkoutRequestValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0);

        RuleFor(x => x.StartAt)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.DurationInMinutes)
            .GreaterThan(0)
            .LessThanOrEqualTo(1440);
    }
}
