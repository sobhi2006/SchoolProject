using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.Commands.Models;

public class DeleteInstructorCommand(Guid Id) : IRequest<Response<string>>
{
    public Guid InstructorId { get; set; } = Id;
}