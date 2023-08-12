using System.ComponentModel.DataAnnotations;

namespace Identity.API.Data.Entity;

public class User
{
    [Key]
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
}
