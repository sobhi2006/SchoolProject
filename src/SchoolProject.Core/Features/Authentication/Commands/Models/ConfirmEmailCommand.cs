using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Commands.Models;

public class ConfirmEmailCommand : IRequest<Response<string>>
{
    public Guid UserId { get; set; }
    public string Code { get; set; }
}