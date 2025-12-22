using DomainUser = FitnessTracker.Domain.Entities.User;
using DataUser = FitnessTracker.Infrastructure.Models.User;

namespace FitnessTracker.Infrastructure.Mappings;

public static class UserMapping
{
    public static DomainUser ToDomain(this DataUser entity)
    {
        return new DomainUser
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            BirthDate = entity.BirthDate.ToDateTime(TimeOnly.MinValue),
            Gender = entity.Gender,
            Height = entity.Height,
            Weight = entity.Weight,
            RegistrationDate = entity.RegistrationDate.ToDateTime(TimeOnly.MinValue)
        };
    }
}
