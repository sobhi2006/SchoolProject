using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class SubjectService : ISubjectService
{
    public Task<Subject?> GetDepartmentByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}