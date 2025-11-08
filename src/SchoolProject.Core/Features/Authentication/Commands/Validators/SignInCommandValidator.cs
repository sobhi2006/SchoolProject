using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace SchoolProject.Core.Features.Authentication.Commands.Validators;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");

        RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .NotNull().WithMessage("{PropertyValue} can't be null");
    }
}
