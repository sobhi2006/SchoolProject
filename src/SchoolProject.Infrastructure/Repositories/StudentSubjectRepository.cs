using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories;

public class StudentSubjectRepository(AppDbContext context) : GenericRepositoryAsync<StudentSubject>(context), IStudentSubjectRepository
{
    private readonly AppDbContext _context = context;

    public async Task<bool> IsStudentExistInSubject(Guid StudentId, Guid SubjectId)
    {
        return await _context.StudentSubjects.AnyAsync(ss => ss.StudentId == StudentId && ss.SubjectId == SubjectId);
    }
}
