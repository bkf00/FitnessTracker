using System.ComponentModel.DataAnnotations;
using FitnessTracker.Api.Validation;

namespace FitnessTracker.Api.Dtos.User;

public class UserCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = null!;

    [Required]
    [MinAge(13)]
    public DateOnly BirthDate { get; set; }

    [Required]
    [MaxLength(10)]
    public string Gender { get; set; } = null!;

    [Range(50, 300)]
    public decimal Height { get; set; }

    [Range(30, 500)]
    public decimal Weight { get; set; }
}
