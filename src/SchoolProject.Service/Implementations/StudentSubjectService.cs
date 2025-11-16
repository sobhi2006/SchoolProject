using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementations;

public class StudentSubjectService(IStudentSubjectRepository studentSubjcetRepository) : IStudentSubjectService
{
    private readonly IStudentSubjectRepository _studentSubjcetRepository = studentSubjcetRepository;

    public Task<bool> AddStudentToSubject(Guid StudentId, Guid SubjectId, float Degree)
    {
        _studentSubjcetRepository.AddAsync(new StudentSubject()
        {
            Id = Guid.NewGuid(),
            SubjectId = SubjectId,
            StudentId = StudentId,
            Degree = Degree
        });
        return Task.FromResult(true);
    }

    public async Task<bool> DeleteStudentToSubject(Guid StudentId, Guid SubjectId)
    {
        await _studentSubjcetRepository.GetTableNoTracking().Where(ss => ss.StudentId == StudentId && ss.SubjectId == SubjectId).ExecuteDeleteAsync();
        return true;
    }

    public async Task<bool> IsStudentExistInSubject(Guid StudnetId, Guid SubjectId)
    {
        return await _studentSubjcetRepository.IsStudentExistInSubject(StudnetId, SubjectId);
    }

    public async Task UpdateStudentToSubject(Guid StudentId, Guid SubjectId, float Degree)
    {
        var result = await _studentSubjcetRepository.GetTableAsTracking()
                                                    .Where(ss => ss.StudentId == StudentId)
                                                    .FirstOrDefaultAsync();
        if(result is null)
            throw new ValidationException("Not Found Student with subject");
        result.SubjectId = SubjectId;
        result.Degree = Degree;
        await _studentSubjcetRepository.SaveChangesAsync();
    }
}
