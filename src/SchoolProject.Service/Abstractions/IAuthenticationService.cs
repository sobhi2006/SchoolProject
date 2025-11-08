using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Service.Abstractions;

public interface IAuthenticationService
{
    public Task<string> GenerateToken(User user);
}