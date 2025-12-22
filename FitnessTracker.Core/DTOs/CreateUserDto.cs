namespace FitnessTracker.Core.DTOs;

public class CreateUserDto
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public decimal Height { get; set; }

    public decimal Weight { get; set; }
}
