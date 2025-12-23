using FitnessTracker.Core.Dtos.User;
using FitnessTracker.Core.Exceptions;
using FitnessTracker.Core.Mappers;
using FitnessTracker.Core.Repository;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Domain.Enums;

namespace FitnessTracker.Core.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<IReadOnlyList<UserDto>> GetAllAsync()
    {
        var users = await _repo.GetAllAsync();
        return users.Select(UserMapper.ToDto).ToList();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user is null ? null : UserMapper.ToDto(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserRequest request)
    {
        // Uniqueness check
        var existing = await _repo.GetByEmailAsync(request.Email);
        if (existing is not null)
            throw new BusinessRuleException("Email already exists.");

        var gender = ParseGender(request.Gender);

        var user = new User(
            request.Name,
            request.Email,
            request.BirthDate,
            gender,
            request.Height,
            request.Weight);

        await _repo.AddAsync(user); // assigns Id back to domain

        return UserMapper.ToDto(user);
    }

    public async Task<UserDto?> UpdateAsync(int id, UpdateUserRequest request)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return null;

        existing.UpdateProfile(request.Name, ParseGender(request.Gender));
        existing.UpdateMeasurements(request.Height, request.Weight);

        var ok = await _repo.UpdateAsync(existing);
        if (!ok) return null;

        return UserMapper.ToDto(existing);
    }

    private static Gender ParseGender(string value)
    {
        if (Enum.TryParse<Gender>(value, ignoreCase: true, out var g))
            return g;

        throw new ArgumentException("Invalid gender.", nameof(value));
    }
}
