namespace SchoolProject.Domain.Entities;

public class DepartmentSubject
{
    public Guid Id { get; set; }
    public Department Department { get; set; } = null!;
    public Guid DepartmentId { get; set; }
    public Subject Subject { get; set; } = null!;
    public Guid SubjectId { get; set; }
}