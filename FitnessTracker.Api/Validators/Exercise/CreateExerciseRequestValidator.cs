using FitnessTracker.Core.Dtos.Exercise;
using FluentValidation;

namespace FitnessTracker.Api.Validators.Exercise;

public sealed class CreateExerciseRequestValidator
    : AbstractValidator<CreateExerciseRequest>
{
    public CreateExerciseRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.MuscleGroup)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.DifficultyLevel)
            .NotEmpty()
            .MaximumLength(20);
    }
}
