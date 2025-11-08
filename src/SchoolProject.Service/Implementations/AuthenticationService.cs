using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class AuthenticationService(JwtSettings jwtSettings) : IAuthenticationService
{
    private readonly JwtSettings _jwtSettings = jwtSettings;

    public Task<string> GenerateToken(User user)
    {
        var Claims = new List<Claim>
        {
            new ("Sub", user.Id),
            new ("UserName", user.UserName!),
            new ("Email", user.Email!),
        };
        var jwtToken = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, Claims, null, DateTime.UtcNow.AddMinutes(2),
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256));
        var Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return Task.FromResult(Token);
    }
}