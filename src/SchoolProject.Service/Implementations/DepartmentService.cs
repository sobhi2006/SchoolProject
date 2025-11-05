using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;

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

    public async Task<bool> IsDepartmentExist(Guid DepartmentId)
    {
        return await _departmentRepository.GetTableNoTracking().AnyAsync(d => d.Id == DepartmentId);
    }
}