using FitnessTracker.Core.Dtos.Workout;
using FluentValidation;

namespace FitnessTracker.Api.Validators.Workout;

public sealed class UpdateWorkoutRequestValidator
    : AbstractValidator<UpdateWorkoutRequest>
{
    public UpdateWorkoutRequestValidator()
    {
        RuleFor(x => x.DurationInMinutes)
            .GreaterThan(0)
            .LessThanOrEqualTo(1440);
    }
}
