using FitnessTracker.Core.Dtos.Goal;
using FluentValidation;

namespace FitnessTracker.Api.Validators.Goal;

public sealed class UpdateGoalRequestValidator
    : AbstractValidator<UpdateGoalRequest>
{
    public UpdateGoalRequestValidator()
    {
        RuleFor(x => x.TargetValue)
            .GreaterThan(0);

        RuleFor(x => x.EndDate)
            .GreaterThan(DateOnly.FromDateTime(DateTime.UtcNow));
    }
}
