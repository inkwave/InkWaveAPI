using Inkwave.Application.DTOs.Email;

namespace Inkwave.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail);
        Task SendAsync(EmailRequestDto request);
    }
}
