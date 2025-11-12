using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Emails.Commands.Handler;

public class EmailCommandHandler(IEmailService emailService) : ResponseHandler,
            IRequestHandler<SendEmailCommand, Response<string>>
{
    private readonly IEmailService _emailService = emailService;

    public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        return await _emailService.SendEmail(request.Email, request.Message, "Message")? Success("Send Successfully")
                                                                            : BadRequest<string>("Send Failed");
    }
}