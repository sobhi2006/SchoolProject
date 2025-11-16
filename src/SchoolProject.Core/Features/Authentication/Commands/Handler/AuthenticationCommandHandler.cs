using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authentication.Commands.Handler;

public class AuthenticationCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager,
                                          IAuthenticationService authenticationService,
                                          IEmailService emailService) : ResponseHandler,
                                                    IRequestHandler<SignInCommand, Response<JwtResponse>>,
                                                    IRequestHandler<RefreshTokenCommand, Response<JwtResponse>>,
                                                    IRequestHandler<ConfirmEmailCommand, Response<string>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IAuthenticationService _authenticationService = authenticationService;
    private readonly IEmailService _emailService = emailService;

    public async Task<Response<JwtResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
            return NotFound<JwtResponse>("User not found");
        var resultSignIn = _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!resultSignIn.IsCompletedSuccessfully)
            return BadRequest<JwtResponse>("UserName Or Password is UnCorrect");

        if (!user.EmailConfirmed)
            return BadRequest<JwtResponse>("Please Confirm your email");

        System.Console.WriteLine(
                "before generate token"
        );
        var AccessToken = await _authenticationService.GenerateToken(user);
        return Success<JwtResponse>(AccessToken);
    }

    public async Task<Response<JwtResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var response = await _authenticationService.RefreshToken(request.AccessToken, request.RefreshToken);
        return Success(response);
    }

    public async Task<Response<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        await _emailService.ConfirmEmailByCode(request.UserId, request.Code);
        return Success("Email Confirmed Successfully");
    }
}