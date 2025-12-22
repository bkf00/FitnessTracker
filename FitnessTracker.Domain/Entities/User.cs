using FitnessTracker.Domain.Enums;

namespace FitnessTracker.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public DateOnly BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public decimal Height { get; private set; }
    public decimal Weight { get; private set; }
    public DateOnly RegistrationDate { get; private set; }

    private User() { }

    public User(string name, string email, DateOnly birthDate, Gender gender, decimal height, decimal weight)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Height = height;
        Weight = weight;
        RegistrationDate = DateOnly.FromDateTime(DateTime.UtcNow);
    }

    public void SetId(int id) => Id = id;

    public void UpdateProfile(string name, Gender gender)
    {
        Name = name;
        Gender = gender;
    }

    public void UpdateMeasurements(decimal height, decimal weight)
    {
        Height = height;
        Weight = weight;
    }
}
