using Microsoft.AspNetCore.Http;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Service.Abstractions;

public interface IInstructorService
{
    Task<bool> IsExistInstructor(string Name);
    Task<bool> AddInstructorAsync(Instructor instructor, IFormFile file);
}