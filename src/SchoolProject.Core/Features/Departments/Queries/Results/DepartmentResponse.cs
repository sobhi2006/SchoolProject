namespace SchoolProject.Core.Features.Departments.Queries.Results;

public class DepartmentResponse
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public string ManagerName { get; set; }
    public List<StudentResponse>? Students { get; set; }
    public List<InstructorResponse>? Instructors { get; set; }
    public List<SubjectResponse>? Subjects { get; set; }
}
public class StudentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class InstructorResponse
{
    public Guid Id { get; set; }
    public string Name{ get; set; }
}

public class SubjectResponse
{
    public Guid Id { get; set; }
    public string SubjectName{ get; set; }
}