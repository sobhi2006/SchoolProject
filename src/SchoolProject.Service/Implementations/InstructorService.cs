using System.Transactions;
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

    public async Task<bool> DeleteInstructorAsync(Guid InstructorId)
    {
        try
        {
            var result = await _instructorRepository.GetTableNoTracking().Where(i => i.Id == InstructorId).ExecuteDeleteAsync();
            return result > 0;    
        }
        catch
        {
            return false;    
        }
    }

    public async Task<Instructor?> GetInstructorById(Guid Id)
    {
        var instructor = await _instructorRepository.GetByIdAsync(Id);
        return instructor;
    }

    public IQueryable<Instructor> GetQueryableInstructor()
    {
        return _instructorRepository.GetTableNoTracking();
    }

    public async Task<bool> IsExistInstructor(string Name)
    {
        return await _instructorRepository.GetTableNoTracking().AnyAsync(i => i.Name == Name);
    }

    public async Task<bool> IsExistInstructor(Guid Id)
    {
        return await _instructorRepository.GetTableNoTracking().AnyAsync(i => i.Id == Id);
    }

    public async Task UpdateInstructorAsync(Instructor Instructor, IFormFile file)
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var imgUrl = await _imageService.SaveImageAsync(file, "Instructors");
        Instructor.ImageUrl = imgUrl;
        await _instructorRepository.UpdateAsync(Instructor);
        scope.Complete();
    }
}