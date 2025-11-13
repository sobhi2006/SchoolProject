using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class InstructorService(IInstructorRepository instructorRepository, IImageService imageService) : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository = instructorRepository;
    private readonly IImageService _imageService = imageService;

    public async Task<bool> AddInstructorAsync(Instructor instructor, IFormFile file)
    {
        var imgUrl = await _imageService.SaveImageAsync(file, "Instructors");
        instructor.ImageUrl = imgUrl;
        var result = await _instructorRepository.AddAsync(instructor);
        return result is not null;
    }

    public async Task<bool> IsExistInstructor(string Name)
    {
        return await _instructorRepository.GetTableNoTracking().AnyAsync(i => i.Name == Name);
    }
}