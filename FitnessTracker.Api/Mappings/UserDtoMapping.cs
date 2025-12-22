using FitnessTracker.Api.DTOs;
using DomainUser = FitnessTracker.Domain.Entities.User;

namespace FitnessTracker.Api.Mappings;

public static class UserDtoMapping
{
    public static UserDto ToDto(this DomainUser domain)
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

    public static DomainUser ToDomain(this CreateUserDto dto)
    {
        return new DomainUser
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
