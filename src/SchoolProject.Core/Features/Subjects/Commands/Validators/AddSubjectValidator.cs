using FluentValidation;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Subjects.Commands.Validators;

public class AddSubjectValidator : AbstractValidator<AddSubjectCommand>
{
    public AddSubjectValidator(ISubjectService subjectService)
    {
        RuleFor(x => x.SubjectName)
                .NotEmpty().WithMessage(" can't be empty")
                .NotNull().WithMessage(" can't be null");

        RuleFor(x => x.Period)
                .NotEmpty().WithMessage(" can't be empty")
                .NotNull().WithMessage(" can't be null");

        RuleFor(x => x.SubjectName)
            .MustAsync(async (key, model) => !await subjectService.IsExistSubjectAsync(key))
            .WithMessage("Subject already found");
    }
}