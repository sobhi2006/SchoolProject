namespace SchoolProject.Core.Features.Subjects.Commands.Models;

public class UpdateSubjectCommand(Guid Id) : AddSubjectCommand
{
    public Guid SubjectId { get; set; } = Id;
}