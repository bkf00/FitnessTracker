using FitnessTracker.Core.Dtos.Goal;
using FluentValidation;

namespace FitnessTracker.Api.Validators.Goal;

public sealed class CreateGoalRequestValidator
    : AbstractValidator<CreateGoalRequest>
{
    public CreateGoalRequestValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);

        RuleFor(x => x.GoalType)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.TargetValue)
            .GreaterThan(0);

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate);

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate);
    }
}
