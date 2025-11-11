using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models;

public class UpdateRoleCommand : IRequest<Response<string>>
{
    public Guid Id { get; set; }
    public string RoleName{ get; set; }
}