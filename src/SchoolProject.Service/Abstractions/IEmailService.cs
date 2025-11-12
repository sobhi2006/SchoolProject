
namespace SchoolProject.Service.Abstractions;

public interface IEmailService
{
    public Task ConfirmEmailByCode(Guid userId, string code);
    public Task<bool> SendEmail(string Email, string Message, string reason);
}