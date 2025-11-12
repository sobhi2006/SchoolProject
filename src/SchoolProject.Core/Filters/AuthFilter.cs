using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Org.BouncyCastle.Pqc.Crypto.Ntru;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.AuthService.Interfaces;

namespace SchoolProject.Core.Filters;

public class AuthFilter(ICurrentUserService currentUserService, UserManager<User> userManager) : IAsyncAuthorizationFilter
{
    private readonly ICurrentUserService _currentUserService = currentUserService;
    private readonly UserManager<User> _userManager = userManager;

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            return;

        if (!await _userManager.IsEmailConfirmedAsync(
                await _userManager.FindByIdAsync(
                await _currentUserService.GetCurrentUserId())))
        {
            context.Result = new UnauthorizedResult();
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.HttpContext.Response.WriteAsync("Please confirm your email");
        }
    }
}