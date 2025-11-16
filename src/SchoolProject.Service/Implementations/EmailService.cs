using System.ComponentModel.DataAnnotations;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class EmailService(UserManager<User> userManager) : IEmailService
{
    private readonly UserManager<User> _userManager = userManager;

    public async Task ConfirmEmailByCode(Guid userId, string code)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new ValidationException("User not found");

        if (await _userManager.IsEmailConfirmedAsync(user))
            throw new ValidationException("user already confirmed");

        var result = await _userManager.ConfirmEmailAsync(user, code.Replace(' ', '+'));
        if (!result.Succeeded)
            throw new ValidationException(string.Join("\n", result.Errors.Select(e => e.Description)));
    }

    public async Task<bool> SendEmail(string Email, string Message, string reason)
    {
        try
        {
            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587);
            await client.AuthenticateAsync("sobhihazouri2006@gmail.com", "*********");
            var BodyBuilder = new BodyBuilder()
            {
                HtmlBody = $"{Message}",
                TextBody = "Welcome to our school system"
            };

            var message = new MimeMessage()
            {
                Body = BodyBuilder.ToMessageBody()
            };

            message.From.Add(new MailboxAddress("Sobhi-Project", "sobhihazouri2006@gmail.com"));
            message.To.Add(new MailboxAddress("Testing", Email));

            message.Subject = reason;
            await client.SendAsync(message);
            client.Disconnect(true);
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }
}
