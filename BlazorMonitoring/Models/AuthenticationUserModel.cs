using System.ComponentModel.DataAnnotations;

namespace BlazorMonitoring.Models;

public class AuthenticationUserModel
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }

}
