using FitnessTracker.Core.Repositories;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Infrastructure.Context;
using FitnessTracker.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FitnessDbContext _context;

    public UserRepository(FitnessDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
        => await _context.Users
            .Select(u => u.ToDomain())
            .ToListAsync();

    public async Task<User?> GetByIdAsync(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        return entity?.ToDomain();
    }

    public async Task<User> AddAsync(User user)
    {
        var entity = user.ToData();
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToDomain();
    }

    public async Task UpdateAsync(User user)
    {
        var entity = await _context.Users.FindAsync(user.Id);
        if (entity == null) return;

        user.UpdateData(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity == null) return;

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
