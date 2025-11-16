using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;

    public async Task<bool> AddDepartmentAsync(Department department)
    {
        var ExistDepartment = await _departmentRepository.GetTableAsTracking()
                                                         .AnyAsync(s => s.DepartmentName == department.DepartmentName);
        if (ExistDepartment)
            throw new ValidationException("Department already is found");

        department.Id = Guid.NewGuid();
        await _departmentRepository.AddAsync(department);
        return true;
    }

    public async Task<bool> DeleteDepartmentAsync(Guid DepartmentId)
    {
        try
        {
            return await _departmentRepository.GetTableNoTracking().Where(d => d.Id == DepartmentId).ExecuteDeleteAsync()
                > 0;
        }
        catch
        {
            return false;
        }
    }

    public async Task<Department?> GetDepartmentByIdAsync(Guid Id)
    {
        var department = await _departmentRepository.GetTableNoTracking()
                                              .Where(d => d.Id == Id)
                                              .Include(s => s.Students)
                                              .Include(i => i.Instructors)
                                              .Include(ds => ds.DepartmentSubjects).ThenInclude(ds => ds.Subject)
                                              .Include(m => m.Manager)
                                              .FirstOrDefaultAsync();
        return department;
    }

    public IQueryable<Department> GetQueryableDepartment()
    {
        return _departmentRepository.GetTableNoTracking();
    }

    public async Task<bool> IsDepartmentExist(Guid DepartmentId)
    {
        return await _departmentRepository.GetTableNoTracking().AnyAsync(d => d.Id == DepartmentId);
    }

    public async Task<bool> IsDepartmentExist(string Name)
    {
        return await _departmentRepository.GetTableNoTracking().AnyAsync(d => d.DepartmentName == Name);
    }

    public async Task UpdateDepartmentAsync(Department department)
    {
        await _departmentRepository.UpdateAsync(department);
    }
}