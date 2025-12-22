using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(int id, User user);
    Task DeleteAsync(int id);
}
