using System.Security.Cryptography.X509Certificates;
namespace SchoolProject.Domain.Helpers;

public class JwtResponse
{
    public string AccessToken { get; set; } = null!;
    public RefreshToken RefreshToken { get; set; } = null!;
}
public class RefreshToken
{
    public string UserName { get; set; } = null!;
    public string TokenStr { get; set; } = null!;
    public DateTime ExpireAt{ get; set; }
}