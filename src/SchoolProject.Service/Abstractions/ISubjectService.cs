using SchoolProject.Domain.Entities;

namespace SchoolProject.Service.Abstractions;

public interface ISubjectService
{
    public Task<Subject?> GetDepartmentByIdAsync(Guid Id);
}