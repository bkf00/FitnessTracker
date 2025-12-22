using FitnessTracker.Core.DTOs;
using FluentValidation;

namespace FitnessTracker.Api.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(x => x.Gender)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Height)
            .GreaterThan(0)
            .LessThan(300);

        RuleFor(x => x.Weight)
            .GreaterThan(0)
            .LessThan(500);

        RuleFor(x => x.BirthDate)
            .Must(BeAtLeast13)
            .WithMessage("User must be at least 13 years old.");
    }

    private bool BeAtLeast13(DateTime birthDate)
        => birthDate.Date <= DateTime.UtcNow.Date.AddYears(-13);
}
