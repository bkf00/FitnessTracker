using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Api.Dtos.User;

public class UserUpdateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public DateOnly BirthDate { get; set; }

    [Required]
    [MaxLength(10)]
    public string Gender { get; set; } = null!;

    [Range(50, 300)]
    public decimal Height { get; set; }

    [Range(30, 500)]
    public decimal Weight { get; set; }
}
