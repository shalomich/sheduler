using System.ComponentModel.DataAnnotations;

namespace Sheduler.Shared;
public record LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    public string Password { get; init; }
}

