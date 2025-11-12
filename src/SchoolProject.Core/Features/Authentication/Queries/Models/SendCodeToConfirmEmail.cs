using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Queries.Models;

public class SendCodeToConfirmEmail(Guid Id):IRequest<Response<string>>
{
    public Guid UserId { get; set; } = Id;
}
