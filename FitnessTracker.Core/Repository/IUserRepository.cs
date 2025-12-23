using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Repository;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<decimal?> GetCurrentWeightAsync(int userId);
    Task<DateOnly?> GetRegistrationDateAsync(int userId);
    Task<bool> DeleteAsync(int id);
}
