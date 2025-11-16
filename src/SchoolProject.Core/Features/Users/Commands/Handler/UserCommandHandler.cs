using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Users.Commands.Handler;

public class UserCommandHandler(IMapper mapper, UserManager<User> userManager,
                                IHttpContextAccessor httpContextAccessor,
                                IEmailService emailService)
                           : ResponseHandler,
                             IRequestHandler<AddUserCommand, Response<string>>,
                             IRequestHandler<UpdateUserCommand, Response<string>>,
                             IRequestHandler<DeleteUserCommand, Response<string>>,
                             IRequestHandler<ChangePasswordCommand, Response<string>>
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IEmailService _emailService = emailService;

    public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByIdAsync(request.Id.ToString());
        if (User is null)
            return NotFound<string>("Student not found");

        var userName = await _userManager.Users.AnyAsync(u => u.UserName == request.UserName && u.Id != request.Id.ToString());
        if (userName)
            return BadRequest<string>("userName is existed");

        var UserMapped = _mapper.Map(request, User);
        var result = await _userManager.UpdateAsync(UserMapped);
        return !result.Succeeded ? BadRequest<string>(string.Join("\n", result.Errors.Select(e => e.Description))) : Success<string>("Updated Successfully");
    }

    public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByIdAsync(request.Id.ToString());
        if (User is null)
            return NotFound<string>("User not found");

        var result = await _userManager.DeleteAsync(User);
        if (!result.Succeeded)
            return BadRequest<string>(string.Join("\n", result.Errors.Select(e => e.Description)));

        return Success<string>("Deleted Successfully");
    }

    public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByIdAsync(request.Id.ToString());
        if (User is null)
            return NotFound<string>("User not found");

        var result = await _userManager.ChangePasswordAsync(User, request.OldPassword, request.NewPassword);

        if (!result.Succeeded)
            return BadRequest<string>(string.Join("\n", result.Errors.Select(e => e.Description)));

        return Success<string>("Change password Successfully");
    }

    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is not null)
            return BadRequest<string>("Email is existed");

        var userName = await _userManager.FindByNameAsync(request.UserName);
        if (userName is not null)
            return BadRequest<string>("userName is existed");

        var UserMapped = _mapper.Map<User>(request);
        var CreatedUser = await _userManager.CreateAsync(UserMapped, request.Password);
        if (!CreatedUser.Succeeded)
            return BadRequest<string>(string.Join("\n", CreatedUser.Errors.Select(e => e.Description)));

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(UserMapped);
        var requestAccessor = _httpContextAccessor.HttpContext.Request;
        var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host +
                        $"/api/v1/Authentication/confirm-email-ByCode?userId={UserMapped.Id}&code={code}";
        var message = $"To Confirm your email click on Link: <a href='{returnUrl}'></a>";
        var SendEmail = await _emailService.SendEmail(UserMapped.Email, message, "Added you to School System");

        var IfFailureSend = requestAccessor.Scheme + "://" + requestAccessor.Host +
                        $"/api/v1/Authentication/code-email-confirm?userId={UserMapped.Id}";
        return SendEmail ? Created("Add User Successfully, Check your email and confirm it") 
                         : Created($"Add User Successfully, but wait a little time to send confirm code,\nTry again to send code on :\n{IfFailureSend}");
    }
}