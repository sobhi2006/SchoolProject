namespace SchoolProject.Domain.Entities;

public class InstructorSubject
{
    public Guid Id { get; set; }
    public Instructor Instructor { get; set; } = null!;
    public Guid InstructorId { get; set; }
    public Subject Subject { get; set; } = null!;
    public Guid SubjectId { get; set; }
}