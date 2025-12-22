namespace FitnessTracker.Core.Dtos.User;

public sealed class UpdateUserRequest
{
    public string Name { get; init; } = default!;
    public string Gender { get; init; } = default!;
    public decimal Height { get; init; }
    public decimal Weight { get; init; }
}
