using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Service.Abstractions;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolProject.Service.Implementations;

public class ImageService(IWebHostEnvironment webHostEnvironment) : IImageService
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<string> SaveImageAsync(IFormFile Image, string Location)
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath,
                                Location);
        try
        {
            if (Image.Length > 0)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //using FileStream stream = File.Create(path);
                //await Image.CopyToAsync(stream);
                //await stream.FlushAsync();
                path = Path.Combine(path, Guid.NewGuid().ToString() +
                                Path.GetExtension(Image.FileName));

                using var stream = new FileStream(path, FileMode.Create);
                await Image.CopyToAsync(stream);
            }
            else
                throw new ValidationException("No Image");
    
        }
        catch (Exception ex)
        {
            throw new ValidationException(ex.Message);
        }
        return path;
    }
}