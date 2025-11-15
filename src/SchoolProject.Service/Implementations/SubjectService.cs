using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository = subjectRepository;

    public async Task<bool> AddSubjectAsync(Subject subject)
    {
        await _subjectRepository.AddAsync(subject);
        return true;
    }

    public async Task<bool> DeleteSubjectAsync(Guid Id)
    {
        try
        {
            return await _subjectRepository.GetTableNoTracking().Where(s => s.Id == Id).ExecuteDeleteAsync() > 0;
        }
        catch
        {
            return false;
        }
    }

    public async Task<Subject?> GetSubjectByIdAsync(Guid Id)
    {
        return await _subjectRepository.GetByIdAsync(Id);
    }

    public IQueryable<Subject> GetSubjectsQueryable()
    {
        return _subjectRepository.GetTableNoTracking();
    }

    public async Task<bool> IsExistSubjectAsync(Guid Id)
    {
        return await _subjectRepository.GetTableNoTracking().AnyAsync(s => s.Id == Id);
    }

    public async Task<bool> IsExistSubjectAsync(string Name)
    {
        return await _subjectRepository.GetTableNoTracking().AnyAsync(s => s.SubjectName == Name);
    }

    public async Task<bool> UpdateSubjectAsync(Subject subject)
    {
        await _subjectRepository.UpdateAsync(subject);
        return true;
    }
}