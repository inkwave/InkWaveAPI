namespace Inkwave.Domain;

public class UserActivedEvent : BaseEvent
{
    public User User { get; }

    public UserActivedEvent(User User)
    {
        this.User = User;
    }
}
