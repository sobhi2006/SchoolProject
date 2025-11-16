using FluentValidation;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Subjects.Commands.Validators;

public class UpdateSubjectValidator : AbstractValidator<UpdateSubjectCommand>
{
    public UpdateSubjectValidator(ISubjectService subjectService, IStudentService studentService)
    {
        RuleFor(s => s.SubjectId)
            .NotEmpty().WithMessage(" can't be empty")
            .NotNull().WithMessage(" can't be null");

        Include(new AddSubjectValidator(subjectService, studentService));
        
        RuleFor(x => x.SubjectId)
            .MustAsync(async (key, model) => await subjectService.IsExistSubjectAsync(key))
            .WithMessage("Subject not found");
    }
}