using FluentValidation;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Departments.Commands.Validators;

public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentValidator(IInstructorService instructorService, IDepartmentService departmentService)
    {
        Include(new AddDepartmentValidator(instructorService, departmentService));
        RuleFor(d => d.departmentId)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" mustn't be empty");
    }
}
