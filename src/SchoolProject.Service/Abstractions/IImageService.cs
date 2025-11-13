using Microsoft.AspNetCore.Http;

namespace SchoolProject.Service.Abstractions;

public interface IImageService
{
    public Task<string> SaveImageAsync(IFormFile Image, string Location);
}