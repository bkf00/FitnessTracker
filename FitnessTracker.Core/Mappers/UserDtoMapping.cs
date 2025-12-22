using FitnessTracker.Core.DTOs;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Mappers;

public static class UserDtoMapper
{
    public static UserDto ToDto(this User domain)
    {
        return new UserDto
        {
            Id = domain.Id,
            Name = domain.Name,
            Email = domain.Email,
            BirthDate = domain.BirthDate,
            Gender = domain.Gender,
            Height = domain.Height,
            Weight = domain.Weight,
            RegistrationDate = domain.RegistrationDate
        };
    }

    public static User ToDomain(this CreateUserDto dto)
    {
        return new User
        {
            Name = dto.Name,
            Email = dto.Email,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            Height = dto.Height,
            Weight = dto.Weight,
            RegistrationDate = DateTime.UtcNow
        };
    }
}
