using Inkwave.Application.Interfaces;
using Inkwave.Domain.User;
using MediatR;

namespace Inkwave.Application.Features.Users.Events;

internal sealed class SendActiveUserCodeDomainEventHandler : INotificationHandler<SendActiveUserCodeDomainEvent>
{
    private readonly IEmailService emailService;
    public SendActiveUserCodeDomainEventHandler(IEmailService emailService)
    {
        this.emailService = emailService;
    }
    public Task Handle(SendActiveUserCodeDomainEvent notification, CancellationToken cancellationToken)
    {
        if (notification.User == null) return Task.CompletedTask;
        var email = new DTOs.Email.EmailRequestDto();
        email.To = notification.User.Email;
        email.Subject = "Inkwave Verify your email address";
        email.Body = $"You need to verify your email address to continue using your Inkwave account. Enter the following code to verify your email address: {notification.User.ActiveCode}";
        emailService.SendAsync(email);
        return Task.CompletedTask;
    }
}
