using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories;

public class StudentRepository(AppDbContext context) : GenericRepositoryAsync<Student>(context), IStudentRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<Student>> GetAllStudentAsync()
    {
        return await _context.Students.Include(s => s.Department).ToListAsync();
    }
}