namespace Inkwave.Domain.Authentication;

public class AuthResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}
