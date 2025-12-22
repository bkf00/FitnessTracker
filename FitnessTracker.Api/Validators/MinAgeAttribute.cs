using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Api.Validation;

public sealed class MinAgeAttribute : ValidationAttribute
{
    private readonly int _minAge;

    public MinAgeAttribute(int minAge)
    {
        _minAge = minAge;
        ErrorMessage = $"User must be at least {_minAge} years old.";
    }

    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        if (value is not DateOnly birthDate)
            return new ValidationResult("Invalid birth date.");

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        var age = today.Year - birthDate.Year;
        if (birthDate.AddYears(age) > today)
            age--;

        return age >= _minAge
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage);
    }
}
