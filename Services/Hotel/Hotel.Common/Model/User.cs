namespace Hotel.Common.Model;

public record User
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
}
