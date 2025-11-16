using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Subjects.Commands.Models;

public class AddSubjectCommand : IRequest<Response<string>>
{
    public string SubjectName { get; set; } = null!;
    public TimeSpan Period { get; set; }
    public float Degree { get; set; }
    public Guid StudentId { get; set; }
}