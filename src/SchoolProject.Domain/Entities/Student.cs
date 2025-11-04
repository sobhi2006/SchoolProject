namespace SchoolProject.Domain.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = []; 
}