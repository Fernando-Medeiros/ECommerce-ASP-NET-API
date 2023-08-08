namespace ECommerce.Modules.Session;

public class EnvironmentDTO
{
    public string PrivateKey { get; set; } = String.Empty;
    public int TokenExpires { get; set; }
}
