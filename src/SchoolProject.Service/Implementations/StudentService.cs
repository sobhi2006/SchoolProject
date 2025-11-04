using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helpers.Enums;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    public async Task<Student?> AddAsync(Student student)
    {
        var ExistStudent = await _studentRepository.GetTableAsTracking().AnyAsync(s => s.Name == student.Name);

        if (ExistStudent)
            return null;

        student.Id = Guid.NewGuid();
        return await _studentRepository.AddAsync(student);
    }

    public async Task<Student?> DeleteAsync(Student student)
    {
        await _studentRepository.DeleteAsync(student);
        return student;
    }

    public async Task<Student?> GetStudentByIdAsync(Guid Id)
    {
        var student = await _studentRepository.GetTableNoTracking()
                                        .Include(s => s.Department)
                                        .Where(s => s.Id == Id).FirstOrDefaultAsync();
        return student;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _studentRepository.GetAllStudentAsync();
    }

    public async Task<bool> IsExistByName(string Name)
    {
        return await _studentRepository.GetTableNoTracking().Where(s => s.Name == Name).AnyAsync();
    }

    public async Task<bool> IsExistByNameExclude(string Name, Guid Id)
    {
        return await _studentRepository.GetTableNoTracking().Where(s => s.Name == Name && s.Id != Id).AnyAsync();
    }

    public async Task<Student?> UpdateAsync(Student student)
    {
        await _studentRepository.UpdateAsync(student);
        return student;
    }

    public IQueryable<Student> GetStudentsQueryable()
    {
        return _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
    }

    public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrdering OrderBy, string Search)
    {
        System.Console.WriteLine("\n\nSearch and ordering student : " + "search : " + Search.ToString() + "order: " + OrderBy);
        var query = _studentRepository.GetTableNoTracking();
        if (Search is not null)
            query = query.Where(s => s.Name.Contains(Search) || s.Address.Contains(Search));

        switch (OrderBy)
        {
            case StudentOrdering.Id:
                query = query.OrderBy(s => s.Id);
                break;

            case StudentOrdering.Name:
                query = query.OrderBy(s => s.Name);
                break;

            case StudentOrdering.Address:
                query = query.OrderBy(s => s.Address);
                break;

            case StudentOrdering.DepartmentName:
                query = query.OrderBy(s => s.Department.DepartmentName);
                break;
            default:
                break;
        }
        return query;
    }
}