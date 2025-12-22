namespace FitnessTracker.Core.Dtos.User;

public sealed class UserDto
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateOnly BirthDate { get; init; }
    public string Gender { get; init; } = default!;
    public decimal Height { get; init; }
    public decimal Weight { get; init; }
    public DateOnly RegistrationDate { get; init; }
}
