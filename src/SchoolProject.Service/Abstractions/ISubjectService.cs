using SchoolProject.Domain.Entities;

namespace SchoolProject.Service.Abstractions;

public interface ISubjectService
{
    public Task<Subject?> GetSubjectByIdAsync(Guid Id);
    public Task<bool> IsExistSubjectAsync(Guid Id);
    public Task<bool> IsExistSubjectAsync(string Name);
    public Task<bool> AddSubjectAsync(Subject subject);
    public Task<bool> UpdateSubjectAsync(Subject subject);
    public Task<bool> DeleteSubjectAsync(Guid Id);
    public IQueryable<Subject> GetSubjectsQueryable();
}