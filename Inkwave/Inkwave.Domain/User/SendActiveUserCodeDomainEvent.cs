using Inkwave.Domain.Common;

namespace Inkwave.Domain.User;

public class SendActiveUserCodeDomainEvent : BaseEvent
{
    public User User { get; }

    public SendActiveUserCodeDomainEvent(User User)
    {
        this.User = User;
    } 
}
