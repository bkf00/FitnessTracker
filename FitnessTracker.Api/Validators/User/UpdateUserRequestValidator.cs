using FitnessTracker.Core.Dtos.User;
using FluentValidation;

namespace FitnessTracker.Api.Validators.User;

public sealed class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Gender)
            .NotEmpty()
            .Must(BeValidGender)
            .WithMessage("Invalid gender.");

        RuleFor(x => x.Height)
            .GreaterThan(0)
            .LessThan(300);

        RuleFor(x => x.Weight)
            .GreaterThan(0)
            .LessThan(500);
    }

    private static bool BeValidGender(string value)
        => Enum.TryParse<FitnessTracker.Domain.Enums.Gender>(
            value,
            ignoreCase: true,
            out _);
}
