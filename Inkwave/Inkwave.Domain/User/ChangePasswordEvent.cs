namespace Inkwave.Domain;

internal class ChangePasswordEvent : BaseEvent
{
    private User user;

    public ChangePasswordEvent(User user)
    {
        this.user = user;
    }
}