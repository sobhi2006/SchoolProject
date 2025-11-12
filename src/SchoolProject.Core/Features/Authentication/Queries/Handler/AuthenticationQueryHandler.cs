using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authentication.Queries.Handler;

public class AuthenticationCommandHandler(UserManager<User> userManager,
                                          IHttpContextAccessor httpContextAccessor,
                                          IEmailService emailService) : ResponseHandler,
                                                    IRequestHandler<SendCodeToConfirmEmail, Response<string>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IEmailService _emailService = emailService;

    public async Task<Response<string>> Handle(SendCodeToConfirmEmail request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var requestAccessor = _httpContextAccessor.HttpContext.Request;
        var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host +
                        $"/api/v1/Authentication/confirm-email-ByCode?userId={user.Id}&code={code}";
        var message = $"To Confirm your email click on Link: <a href='{returnUrl}'></a>";

        var SendEmail = await _emailService.SendEmail(user.Email, message, "Send Code to Confirm you email");

        var IfFailureSend = requestAccessor.Scheme + "://" + requestAccessor.Host +
                        $"/api/v1/Authentication/code-email-confirm?userId={user.Id}";
        return SendEmail ? Success("Check your email and confirm it") 
                         : Success($"Wait a little time to send confirm code,\nTry again to send code on :\n{IfFailureSend}");
    }
}