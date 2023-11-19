namespace Inkwave.Domain;

internal class UserUpdatedEvent : BaseEvent
{
    private User user;

    public UserUpdatedEvent(User user)
    {
        this.user = user;
    }
}