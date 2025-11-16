using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace SchoolProject.Core.Features.Authentication.Commands.Validators;

public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailValidator()
    {
        RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");
    }
}