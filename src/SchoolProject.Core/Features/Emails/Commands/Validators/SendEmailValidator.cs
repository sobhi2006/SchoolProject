using FluentValidation;
using SchoolProject.Core.Features.Emails.Commands.Models;

namespace SchoolProject.Core.Features.Emails.Commands.Validators;

public class SendEmailValidator : AbstractValidator<SendEmailCommand>
{
    public SendEmailValidator()
    {
        RuleFor(r => r.Email)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty")
            .EmailAddress().WithMessage("invalid email.");

        RuleFor(r => r.Message)
            .NotNull().WithMessage(" is required")
            .NotEmpty().WithMessage(" must not empty");
    }
}