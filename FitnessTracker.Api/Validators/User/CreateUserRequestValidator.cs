using FitnessTracker.Core.Dtos.User;
using FluentValidation;

namespace FitnessTracker.Api.Validators.User;

public sealed class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(x => x.BirthDate)
            .Must(BeAtLeast13YearsOld)
            .WithMessage("User must be at least 13 years old.");

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

    private static bool BeAtLeast13YearsOld(DateOnly birthDate)
    {
        var today = DateTime.UtcNow.Date;

        // SQL Server equivalent of DATEDIFF(YEAR, BirthDate, GETDATE())
        var age = today.Year - birthDate.Year;

        return age >= 13;
    }

    private static bool BeValidGender(string value)
        => Enum.TryParse<FitnessTracker.Domain.Enums.Gender>(
            value,
            ignoreCase: true,
            out _);
}
