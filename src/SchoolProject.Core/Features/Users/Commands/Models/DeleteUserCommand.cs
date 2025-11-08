using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models;

public class DeleteUserCommand(Guid id) : IRequest<Response<string>>
{
    public Guid Id { get; set; } = id;
}