using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.Commands.Models;

public class UpdateInstructorCommand(Guid Id) : AddInstructorCommand
{
    public Guid InstructorId { get; set; } = Id;
}