using Inkwave.Application.DTOs.Email;
using Inkwave.Application.Interfaces;
using Inkwave.Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Inkwave.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public MailSettings mailSettings { get; }
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }

        public async Task SendWelcomeEmailAsync(string toEmail)
        {
            // Set up SMTP client
            var emailClient = new SmtpClient(mailSettings.Host, mailSettings.Port);
            emailClient.EnableSsl = true;
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password);

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailSettings.Mail);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "Welcome to Ink Waves";
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();

            mailBody.AppendFormat($"< div style = \"color:inherit;font-size:inherit;line-height:inherit\" > ");
            mailBody.AppendFormat($" < h2 style = \"margin:0;font-size:18px;line-height:250%\" > ");
            mailBody.AppendFormat($"<span style = \"font-size:20px\" > Get comfortable and enjoy the trip! </ span > ");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("< p style = \"line-height:175%\" > Your account has been successfully activated.Now, your experience will be more complete thanks to the following benefits:</ p >");
            mailBody.AppendFormat("<p>Thank you For Registering account</p>");
            mailBody.AppendFormat("</div>");


            mailMessage.Body = mailBody.ToString();

            await Send(mailMessage);

            //< ul style = "line-height:175%" >
            //  < li style = "line-height:175%" > Access your account via Gmail or Facebook</ li >
            //  < li style = "line-height:175%" > Mark templates as favorites so you can easily find them later </ li >
            //  < li style = "line-height:175%" > Access your download history </ li >
            //  < li style = "line-height:175%" > Download 10 templates every month for free! </ li >
            //</ ul > 


        }
        public async Task SendAsync(EmailRequestDto request)
        {
            var message = new MailMessage
            {
                From = new MailAddress(request.From),
                Subject = request.Subject,
                Body = request.Body
            };
            message.To.Add(new MailAddress(request.To));
            await Send(message);
        }
        async Task Send(MailMessage mailMessage)
        {
            var emailClient = new SmtpClient(mailSettings.Host, mailSettings.Port);
            emailClient.EnableSsl = true;
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password);
            await emailClient.SendMailAsync(mailMessage);
        }
    }
}
