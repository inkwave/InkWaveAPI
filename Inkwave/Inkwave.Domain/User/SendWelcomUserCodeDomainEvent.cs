using Inkwave.Domain.Common;

namespace Inkwave.Domain.User;

public class SendWelcomUserCodeDomainEvent : BaseEvent
{
    public User User { get; }

    public SendWelcomUserCodeDomainEvent(User User)
    {
        this.User = User;
    } 
}
