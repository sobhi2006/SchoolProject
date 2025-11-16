using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helpers.Enums;

namespace SchoolProject.Service.Abstractions;

public interface IStudentService
{
    public Task<List<Student>> GetStudentsAsync();
    public Task<Student?> GetStudentByIdAsync(Guid Id);
    public Task<Student?> AddAsync(Student student);
    public Task<bool> IsExistByName(string Name);
    public Task<bool> IsExistById(Guid studnetId);
    public Task<bool> IsExistByNameExclude(string Name, Guid Id);
    public Task<Student?> UpdateAsync(Student student);
    public Task<Student?> DeleteAsync(Student student);
    public IQueryable<Student> GetStudentsQueryable();
    public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrdering OrderBy, string Search);
    
}