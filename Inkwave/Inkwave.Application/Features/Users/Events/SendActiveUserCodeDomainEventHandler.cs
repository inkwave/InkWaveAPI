using Inkwave.Application.Interfaces;

namespace Inkwave.Application.Features.Users.Events;

internal sealed class SendActiveUserCodeDomainEventHandler : INotificationHandler<SendActiveCodeEvent>
{
    private readonly IEmailService emailService;
    public SendActiveUserCodeDomainEventHandler(IEmailService emailService)
    {
        this.emailService = emailService;
    }
    public Task Handle(SendActiveCodeEvent notification, CancellationToken cancellationToken)
    {
        if (notification.Code == null) return Task.CompletedTask;
        var email = new DTOs.Email.EmailRequestDto();
        email.To = notification.Email;
        email.Subject = "Inkwave Verify your email address";
        email.Body = $"You need to verify your email address to continue using your Inkwave account. Enter the following code to verify your email address: {notification.Code}";
        emailService.SendAsync(email);
        return Task.CompletedTask;
    }
}
