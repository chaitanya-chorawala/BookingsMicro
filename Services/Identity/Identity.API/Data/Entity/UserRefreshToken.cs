using System.ComponentModel.DataAnnotations;

namespace Identity.API.Data.Entity;

public class UserRefreshToken
{
    [Key]
    public string Username { get; set; } = string.Empty;    
    public string Token { get; set; } = string.Empty;
}
