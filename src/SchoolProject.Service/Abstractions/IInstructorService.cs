using Microsoft.AspNetCore.Http;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Service.Abstractions;

public interface IInstructorService
{
    Task<bool> IsExistInstructor(string Name);
    Task<bool> IsExistInstructor(Guid Id);
    Task<bool> AddInstructorAsync(Instructor instructor, IFormFile file);
    public Task UpdateInstructorAsync(Instructor Instructor, IFormFile file);
    public Task<bool> DeleteInstructorAsync(Guid InstructorId);
    public IQueryable<Instructor> GetQueryableInstructor();
    public Task<Instructor?> GetInstructorById(Guid Id);
}