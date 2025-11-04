using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class InstructorService : IInstructorService
{
    public Task<Instructor?> GetDepartmentByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}