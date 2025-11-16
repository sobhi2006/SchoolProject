using FluentValidation;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructors.Commands.Validator;

public class UpdateInstructorValidator : AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorValidator(IInstructorService instructorService)
    {
        RuleFor(d => d.Id)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" mustn't be empty");

        RuleFor(s => s.Id)
                .MustAsync(async (Key, model) => await instructorService.IsExistInstructor(Key))
                .WithMessage("Instructor not found");

        RuleFor(r => r.Name)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty");

        RuleFor(r => r.Address)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty");

        RuleFor(r => r.DepartmentId)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty");

        RuleFor(r => r.Salary)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty");

        RuleFor(r => r.Position)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty");

        RuleFor(r => r.Image)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty");


        RuleFor(i => i.Name)
            .MustAsync(async (key, model) => !await instructorService.IsExistInstructor(key))
            .WithMessage("Instructor was found");
    }
}
