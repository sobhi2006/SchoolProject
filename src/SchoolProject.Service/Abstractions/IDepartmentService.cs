using SchoolProject.Domain.Entities;

namespace SchoolProject.Service.Abstractions;

public interface IDepartmentService
{
    public Task<Department?> GetDepartmentByIdAsync(Guid Id);
    public Task<bool> IsDepartmentExist(Guid DepartmentId);
    public Task<bool> IsDepartmentExist(string Name);
    public Task<bool> AddDepartmentAsync(Department department);
    public Task UpdateDepartmentAsync(Department department);
    public Task<bool> DeleteDepartmentAsync(Guid DepartmentId);
    public IQueryable<Department> GetQueryableDepartment();
}