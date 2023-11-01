using Inkwave.Application.DTOs.Email;
using Inkwave.Application.Interfaces;
using Inkwave.Domain.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Inkwave.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public MailSettings mailSettings { get; }
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }

       
        public async Task SendAsync(EmailRequestDto request)
        {
            var message = new MailMessage();
            message.From = string.IsNullOrWhiteSpace(request.From) ? new MailAddress(mailSettings.Mail) : new MailAddress(request.From);
            message.Subject = request.Subject;
            message.Body = request.Body;
            message.IsBodyHtml = request.IsBodyHtml;
            message.To.Add(new MailAddress(request.To));
            await Send(message);
        }
        private async Task Send(MailMessage mailMessage)
        {
            var emailClient = new SmtpClient(mailSettings.Host, mailSettings.Port);
            emailClient.EnableSsl = true;
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password);
            await emailClient.SendMailAsync(mailMessage);
        }
    }
}
