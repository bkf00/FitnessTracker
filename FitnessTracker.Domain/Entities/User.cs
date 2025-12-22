namespace FitnessTracker.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public decimal Height { get; set; }

    public decimal Weight { get; set; }

    public DateTime RegistrationDate { get; set; }
}
