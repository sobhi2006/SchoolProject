using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models;

public class RefreshTokenCommand : IRequest<Response<JwtResponse>>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}