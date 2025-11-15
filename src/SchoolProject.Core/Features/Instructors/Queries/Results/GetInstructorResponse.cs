namespace SchoolProject.Core.Features.Instructors.Queries.Results;

public class GetInstructorResponse
{
    public GetInstructorResponse(Guid id, string name, string address, string position, decimal salary, Guid departmentId, Guid? supervisorId, string imageUrl)
    {
        Id = id;
        Name = name;
        Address = address;
        Position = position;
        Salary = salary;
        DepartmentId = departmentId;
        SupervisorId = supervisorId;
        ImageUrl = imageUrl;
    }

    public GetInstructorResponse()
    {
        
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? SupervisorId { get; set; }
    public string ImageUrl { get; set; }
}