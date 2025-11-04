namespace SchoolProject.Domain.Entities;

public class StudentSubject
{
    public Guid Id { get; set; }
    public float Degree{ get; set; }
    public Student Student { get; set; } = null!;
    public Guid StudentId { get; set; }
    public Subject Subject { get; set; } = null!;
    public Guid SubjectId { get; set; }

}