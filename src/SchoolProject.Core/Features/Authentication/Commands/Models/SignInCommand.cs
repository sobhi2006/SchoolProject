using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models;

public class SignInCommand : IRequest<Response<JwtResponse>>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}