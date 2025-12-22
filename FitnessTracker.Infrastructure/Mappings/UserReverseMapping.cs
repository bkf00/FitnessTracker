using DomainUser = FitnessTracker.Domain.Entities.User;
using DataUser = FitnessTracker.Infrastructure.Models.User;

namespace FitnessTracker.Infrastructure.Mappings;

public static class UserReverseMapping
{
    public static DataUser ToData(this DomainUser domain)
    {
        return new DataUser
        {
            Name = domain.Name,
            Email = domain.Email,
            BirthDate = DateOnly.FromDateTime(domain.BirthDate),
            Gender = domain.Gender,
            Height = domain.Height,
            Weight = domain.Weight
            // RegistrationDate handled by DB
        };
    }

    public static void UpdateData(this DomainUser domain, DataUser entity)
    {
        entity.Name = domain.Name;
        entity.Email = domain.Email;
        entity.BirthDate = DateOnly.FromDateTime(domain.BirthDate);
        entity.Gender = domain.Gender;
        entity.Height = domain.Height;
        entity.Weight = domain.Weight;
    }
}
