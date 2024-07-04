namespace _6thElement.API.infrastructure.JwtAuth;

public class JwtConfig
{
    public string Issuer { get; set; } = string.Empty;
    public string Audiance { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public int Exp { get; set; }
}
