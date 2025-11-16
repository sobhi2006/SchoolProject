using FluentValidation;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Subjects.Commands.Validators;

public class AddSubjectValidator : AbstractValidator<AddSubjectCommand>
{
    public AddSubjectValidator(ISubjectService subjectService, IStudentService studentService)
    {
        RuleFor(x => x.SubjectName)
                .NotEmpty().WithMessage(" can't be empty")
                .NotNull().WithMessage(" can't be null");

        RuleFor(x => x.Period)
                .NotEmpty().WithMessage(" can't be empty")
                .NotNull().WithMessage(" can't be null");

        RuleFor(x => x.Degree)
                .NotEmpty().WithMessage(" can't be empty")
                .NotNull().WithMessage(" can't be null")
                .InclusiveBetween(0, 100).WithMessage("Degree must be between 0 - 100");

        RuleFor(x => x.SubjectName)
            .MustAsync(async (key, model) => !await subjectService.IsExistSubjectAsync(key))
            .WithMessage("Subject already found");

        RuleFor(x => x.StudentId)
            .MustAsync(async (key, model) => await studentService.IsExistById(key))
            .WithMessage("Student not found.");
    }
}