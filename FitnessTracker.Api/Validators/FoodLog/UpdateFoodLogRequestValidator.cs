using FitnessTracker.Core.Dtos.FoodLog;
using FluentValidation;

namespace FitnessTracker.Api.Validators.FoodLog;

public sealed class UpdateFoodLogRequestValidator
    : AbstractValidator<UpdateFoodLogRequest>
{
    public UpdateFoodLogRequestValidator()
    {
        RuleFor(x => x.Servings)
            .GreaterThan(0);

        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}
