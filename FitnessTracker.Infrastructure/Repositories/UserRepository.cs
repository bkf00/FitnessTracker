using FitnessTracker.Infrastructure.Context;
using FitnessTracker.Domain.Enums;
using Microsoft.EntityFrameworkCore;

using DomainUser = FitnessTracker.Domain.Entities.User;
using EfUser = FitnessTracker.Infrastructure.Models.User;
using FitnessTracker.Core.Repository;

namespace FitnessTracker.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly FitnessDbContext _context;

    public UserRepository(FitnessDbContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<DomainUser>> GetAllAsync()
    {
        var entities = await _context.Users
            .AsNoTracking()
            .OrderBy(u => u.Name)
            .ToListAsync();

        return entities.Select(MapToDomain).ToList();
    }

    public async Task<DomainUser?> GetByIdAsync(int id)
    {
        EfUser? entity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task<DomainUser?> GetByEmailAsync(string email)
    {
        EfUser? entity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email);

        return entity is null ? null : MapToDomain(entity);
    }

    public async Task AddAsync(DomainUser user)
    {
        EfUser entity = MapToEntity(user);
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();

        user.SetId(entity.Id);
    }

    public async Task<bool> UpdateAsync(DomainUser user)
    {
        EfUser? entity = await _context.Users.FindAsync(user.Id);
        if (entity is null) return false;

        entity.Name = user.Name;
        entity.Gender = user.Gender.ToString();
        entity.Height = user.Height;
        entity.Weight = user.Weight;

        await _context.SaveChangesAsync();
        return true;
    }

    private static DomainUser MapToDomain(EfUser entity)
    {
        var user = new DomainUser(
            entity.Name,
            entity.Email,
            entity.BirthDate,
            Enum.Parse<Gender>(entity.Gender, ignoreCase: true),
            entity.Height,
            entity.Weight
        );

        user.SetId(entity.Id);
        return user;
    }

    private static EfUser MapToEntity(DomainUser domain)
        => new()
        {
            Name = domain.Name,
            Email = domain.Email,
            BirthDate = domain.BirthDate,
            Gender = domain.Gender.ToString(),
            Height = domain.Height,
            Weight = domain.Weight,
            RegistrationDate = domain.RegistrationDate
        };

    public async Task<decimal?> GetCurrentWeightAsync(int userId)
    {
        return await _context.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .Select(u => (decimal?)u.Weight)
            .FirstOrDefaultAsync();
    }
    public async Task<DateOnly?> GetRegistrationDateAsync(int userId)
    {
        return await _context.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .Select(u => (DateOnly?)u.RegistrationDate)
            .FirstOrDefaultAsync();
    }
}
