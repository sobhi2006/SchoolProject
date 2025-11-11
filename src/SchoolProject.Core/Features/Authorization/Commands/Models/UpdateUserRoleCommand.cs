using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models;

public class UpdateUserRoleCommand : IRequest<Response<string>>
{
    public Guid UserId { get; set; }
    public Guid OldRole { get; set; }
    public Guid NewRole { get; set; }
}