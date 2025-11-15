using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Subjects.Commands.Models;

public class DeleteSubjectCommand(Guid Id) : IRequest<Response<string>>
{
    public Guid SubjectId { get; set; } = Id;
}