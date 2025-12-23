using FitnessTracker.Core.Dtos.FoodLog;
using FluentValidation;

namespace FitnessTracker.Api.Validators.FoodLog;

public sealed class CreateFoodLogRequestValidator
    : AbstractValidator<CreateFoodLogRequest>
{
    public CreateFoodLogRequestValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.FoodItemId).GreaterThan(0);

        RuleFor(x => x.LogDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));

        RuleFor(x => x.Servings)
            .GreaterThan(0);

        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}
