namespace FitnessTracker.Core.Dtos.User;

public sealed class CreateUserRequest
{
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateOnly BirthDate { get; init; }
    public string Gender { get; init; } = default!; // "Male"/"Female"/"Other"
    public decimal Height { get; init; }
    public decimal Weight { get; init; }
}
