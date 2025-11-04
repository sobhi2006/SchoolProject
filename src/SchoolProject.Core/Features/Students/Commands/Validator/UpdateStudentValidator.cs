using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Students.Commands.Validator;

public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
{
    private readonly IStudentService _studentService;

    public UpdateStudentValidator(IStudentService studentService)
    {
        _studentService = studentService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id can't be empty")
                .NotNull().WithMessage("Id can't be null");

        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(s => s.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsExistByNameExclude(Key, model.Id))
                .WithMessage("Student by name is exist");
    }
}