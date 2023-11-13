using Inkwave.Domain.Common;

namespace Inkwave.Domain.User;

public class UserActivedEvent : BaseEvent
{
    public User User { get; }

    public UserActivedEvent(User User)
    {
        this.User = User;
    }
}
