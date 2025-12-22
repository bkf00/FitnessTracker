using FitnessTracker.Core.Dtos.Workout;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class WorkoutMapper
{
    public static WorkoutDto ToDto(Workout workout) => new()
    {
        Id = workout.Id,
        UserId = workout.UserId,
        StartAt = workout.StartAt,
        DurationInMinutes = workout.DurationInMinutes,
        Notes = workout.Notes
    };
}
