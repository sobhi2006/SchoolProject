using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstractions;
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
        return services;
    }
}