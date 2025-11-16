using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;

namespace SchoolProject.Service.Abstractions;

public interface IAuthenticationService
{
    public Task<JwtResponse> GenerateToken(User user);
    public Task<JwtResponse> RefreshToken(string AccessToken, string RefreshToken);
    public Task<bool> ValidateToken(string AccessToken);
}