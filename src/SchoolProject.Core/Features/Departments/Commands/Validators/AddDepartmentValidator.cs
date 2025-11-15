using FluentValidation;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Departments.Commands.Validators;

public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>
{
    public AddDepartmentValidator(IInstructorService instructorService, IDepartmentService departmentService)
    {
        RuleFor(d => d.DepartmentName)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" mustn't be empty");

        RuleFor(d => d.ManagerId)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" mustn't be empty");

        RuleFor(d => d.ManagerId)
            .MustAsync(async (key, model) => await instructorService.IsExistInstructor(key))
            .WithMessage("Manager not found");

        RuleFor(d => d.DepartmentName)
            .MustAsync(async (key, model) => !await departmentService.IsDepartmentExist(key))
            .WithMessage("Manager not found");
    }
}