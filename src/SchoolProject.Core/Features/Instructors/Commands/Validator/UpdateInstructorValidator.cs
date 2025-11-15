using FluentValidation;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Instructors.Commands.Validator;

public class UpdateInstructorValidator : AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorValidator(IInstructorService instructorService)
    {
        Include(new AddInstructorCommandValidator(instructorService));
        RuleFor(d => d.InstructorId)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" mustn't be empty");

        RuleFor(s => s.InstructorId)
                .MustAsync(async (Key, model) => await instructorService.IsExistInstructor(Key))
                .WithMessage("Instructor not found");
    }
}
