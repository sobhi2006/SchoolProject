namespace SchoolProject.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; } = null!;
    public virtual ICollection<Student> Students { get; set; } = [];
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = [];
    public virtual ICollection<Instructor> Instructors { get; set; } = [];
    public Instructor? Manager { get; set; } = null!;
    public Guid? ManagerId { get; set; }
}