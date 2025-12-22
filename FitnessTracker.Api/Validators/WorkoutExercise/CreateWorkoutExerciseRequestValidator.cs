using FitnessTracker.Core.Dtos.WorkoutExercise;
using FluentValidation;

namespace FitnessTracker.Api.Validators.WorkoutExercise;

public sealed class CreateWorkoutExerciseRequestValidator
    : AbstractValidator<CreateWorkoutExerciseRequest>
{
    public CreateWorkoutExerciseRequestValidator()
    {
        RuleFor(x => x.WorkoutId).GreaterThan(0);
        RuleFor(x => x.ExerciseId).GreaterThan(0);

        RuleFor(x => x.Sets)
            .GreaterThan(0)
            .LessThanOrEqualTo(20);

        RuleFor(x => x.Reps)
            .GreaterThan(0)
            .LessThanOrEqualTo(100);

        RuleFor(x => x.WeightUsed)
            .GreaterThanOrEqualTo(0)
            .When(x => x.WeightUsed.HasValue);
    }
}
