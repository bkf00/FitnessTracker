using FitnessTracker.Core.Dtos.FoodItem;
using FluentValidation;

namespace FitnessTracker.Api.Validators.FoodItem;

public sealed class CreateFoodItemRequestValidator
    : AbstractValidator<CreateFoodItemRequest>
{
    public CreateFoodItemRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Calories)
            .GreaterThan(0)
            .LessThanOrEqualTo(2000);

        RuleFor(x => x.Protein)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(200);

        RuleFor(x => x.Carbs)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(300);

        RuleFor(x => x.Fat)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(200);
    }
}
