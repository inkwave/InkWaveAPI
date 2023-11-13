using Inkwave.Application.Interfaces;
using Inkwave.Domain.Settings;
using Inkwave.Domain.User;
using MediatR;
using System.Net.Mail;
using System.Text;

namespace Inkwave.Application.Features.Users.Events;

internal sealed class SendWelcomUserCodeDomainEventHandler : INotificationHandler<UserActivedEvent>
{
    private readonly IEmailService emailService;
    public SendWelcomUserCodeDomainEventHandler(IEmailService emailService)
    {
        this.emailService = emailService;
    }
    public Task Handle(UserActivedEvent notification, CancellationToken cancellationToken)
    {
        if (notification.User == null) return Task.CompletedTask;
        var email = new DTOs.Email.EmailRequestDto();
        email.To = notification.User.Email;   
        email.Subject = "Welcome to Ink Waves";
        
        StringBuilder mailBody = new StringBuilder();
        mailBody.AppendFormat($"< div style = \"color:inherit;font-size:inherit;line-height:inherit\" > ");
        mailBody.AppendFormat($" < h2 style = \"margin:0;font-size:18px;line-height:250%\" > ");
        mailBody.AppendFormat($"<span style = \"font-size:20px\" > Get comfortable and enjoy the trip! </ span > ");
        mailBody.AppendFormat("<br />");
        mailBody.AppendFormat("< p style = \"line-height:175%\" > Your account has been successfully activated.Now, your experience will be more complete thanks to the following benefits:</ p >");
        mailBody.AppendFormat("<p>Thank you For Registering account</p>");
        mailBody.AppendFormat("</div>");
        email.Body = mailBody.ToString();
        email.IsBodyHtml = true;

        emailService.SendAsync(email);
        return Task.CompletedTask;
    }
}
