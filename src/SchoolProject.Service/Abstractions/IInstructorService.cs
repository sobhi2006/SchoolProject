using SchoolProject.Domain.Entities;

namespace SchoolProject.Service.Abstractions;

public interface IInstructorService
{
    public Task<Instructor?> GetDepartmentByIdAsync(Guid Id);
}