using SchoolProject.Domain.Entities;

namespace SchoolProject.Service.Abstractions;

public interface IDepartmentService
{
    public Task<Department?> GetDepartmentByIdAsync(Guid Id);
}