using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstractions;
using SchoolProject.Service.AuthService.Implementations;
using SchoolProject.Service.AuthService.Interfaces;
using SchoolProject.Service.Implementations;

namespace SchoolProject.Service;

public static class ServiceDependency
{
    public static IServiceCollection AddServiceDependency(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<IDepartmentService, DepartmentService>();
        services.AddTransient<IInstructorService, InstructorService>();
        services.AddTransient<ISubjectService, SubjectService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IAuthorizationService, AuthorizationService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddTransient<IImageService, ImageService>();
        return services;
    }
}