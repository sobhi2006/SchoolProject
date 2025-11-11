using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models;

public class DeleteRoleCommand(Guid Id) : IRequest<Response<string>>
{
    public Guid Id { get; set; } = Id;
}