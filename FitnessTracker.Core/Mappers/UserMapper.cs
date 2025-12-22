using FitnessTracker.Core.Dtos.User;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

internal static class UserMapper
{
    public static UserDto ToDto(User user) => new()
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        BirthDate = user.BirthDate,
        Gender = user.Gender.ToString(),
        Height = user.Height,
        Weight = user.Weight,
        RegistrationDate = user.RegistrationDate
    };
}
