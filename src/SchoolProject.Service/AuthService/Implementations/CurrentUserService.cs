using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.AuthService.Interfaces;

namespace SchoolProject.Service.AuthService.Implementations;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Task<string> GetCurrentUserId()
    {
        return Task.FromResult(_httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == "Sub")!.Value);
    }

    public Task<User> GetInfoCurrentUser()
    {
        var ClaimsDic = _httpContextAccessor.HttpContext!.User.Claims.ToDictionary(c => c.Type, c => c.Value);

        return Task.FromResult(new User
        {
            Id = ClaimsDic["Sub"],
            Email = ClaimsDic["Email"],
            UserName = ClaimsDic["UserName"]
        });
    }
}