namespace SchoolProject.Domain.Entities;

public class Instructor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Position { get; set; } = null!;
    public decimal Salary { get; set; }
    public Department Department { get; set; } = null!;
    public Guid DepartmentId { get; set; }
    public Department DepartmentManager { get; set; } = null!;
    public Instructor? Supervisor { get; set; }
    public Guid? SupervisorId { get; set; }
    public virtual ICollection<Instructor> Instructors { get; set; } = [];
    public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = [];
}