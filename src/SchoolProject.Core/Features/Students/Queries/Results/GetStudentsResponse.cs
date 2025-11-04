namespace SchoolProject.Core.Features.Queries.Results;

public class GetStudentResponse
{
    public GetStudentResponse(Guid id, string name, string address, string phone, string departmentName)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
        DepartmentName = departmentName;
    }
    public GetStudentResponse() { }

    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;
}