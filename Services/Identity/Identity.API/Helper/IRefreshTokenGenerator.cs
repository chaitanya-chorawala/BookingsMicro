namespace Identity.API.Helper;

public interface IRefreshTokenGenerator
{
    Task<string> GenerateRefreshToken(string username);
}