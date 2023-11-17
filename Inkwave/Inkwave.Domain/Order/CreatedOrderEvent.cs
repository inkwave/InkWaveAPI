namespace Inkwave.Domain;

public class CreatedOrderEvent : BaseEvent
{
    public Order order { get; }

    public CreatedOrderEvent(Order order)
    {
        this.order = order;
    }
}
