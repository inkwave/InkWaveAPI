using Inkwave.Application.DTOs.Email;

namespace Inkwave.Application.Interfaces
{
    public interface IEmailService
    {

        Task SendAsync(EmailRequestDto request);
    }
}
