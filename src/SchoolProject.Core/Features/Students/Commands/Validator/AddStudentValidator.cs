using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Students.Commands.Validator;

public class AddStudentValidator : AbstractValidator<AddStudentCommand>
{
    private readonly IStudentService _studentService;
    private readonly IDepartmentService _departmentService;

    public AddStudentValidator(IStudentService studentService, IDepartmentService departmentService)
    {
        _studentService = studentService;
        _departmentService = departmentService;

        this.ApplyValidationRules();
        this.ApplyCustomValidationRules();
    }
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(s => s.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsExistByName(Key))
                .WithMessage("Student is exist");

        RuleFor(s => s.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => !await _departmentService.IsDepartmentExist(Key))
                .WithMessage("Department Id not found");
    }
}