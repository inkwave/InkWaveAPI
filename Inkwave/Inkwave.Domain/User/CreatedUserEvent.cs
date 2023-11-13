using Inkwave.Domain.Common;

namespace Inkwave.Domain.User;

public class CreatedUserEvent : BaseEvent
{
    public User User { get; }

    public CreatedUserEvent(User User)
    {
        this.User = User;
    }
}
