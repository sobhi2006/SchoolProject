using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authentication.Commands.Handler;

public class SignInCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authenticationService) : ResponseHandler,
                                                    IRequestHandler<SignInCommand, Response<string>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
            return NotFound<string>("User not found");
        var resultSignIn = _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!resultSignIn.IsCompletedSuccessfully)
            return BadRequest<string>("UserName Or Password is UnCorrect");

        System.Console.WriteLine(
                "before generate token"
        );
        var AccessToken = await _authenticationService.GenerateToken(user);
        return Success(AccessToken);
    }
}