using FitnessTracker.Core.Repositories;
using FitnessTracker.Domain.Entities;

namespace FitnessTracker.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<User>> GetAllAsync()
        => _repo.GetAllAsync();

    public Task<User?> GetByIdAsync(int id)
        => _repo.GetByIdAsync(id);

    public Task<User> CreateAsync(User user)
        => _repo.AddAsync(user);

    public async Task UpdateAsync(int id, User user)
    {
        user.Id = id;
        await _repo.UpdateAsync(user);
    }

    public Task DeleteAsync(int id)
        => _repo.DeleteAsync(id);
}
