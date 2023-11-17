namespace Inkwave.Domain;

public class SendActiveCodeEvent : BaseEvent
{
    public string Email { get; }
    public string Code { get; }

    public SendActiveCodeEvent(string email, string code)
    {
        this.Code = code;
        this.Email = email;
    }
}
