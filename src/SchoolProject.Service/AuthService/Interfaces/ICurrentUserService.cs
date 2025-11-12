using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Service.AuthService.Interfaces;

public interface ICurrentUserService
{
    public Task<User> GetInfoCurrentUser();
    public Task<string> GetCurrentUserId();
}