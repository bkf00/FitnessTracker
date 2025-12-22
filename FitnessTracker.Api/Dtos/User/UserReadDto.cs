namespace FitnessTracker.Api.Dtos.User;

public class UserReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public DateOnly RegistrationDate { get; set; }
}
