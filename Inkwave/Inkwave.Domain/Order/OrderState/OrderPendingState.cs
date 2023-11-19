namespace Inkwave.Domain;

public class OrderPendingState : IOrderState
{
    private readonly Order order;

    public OrderPendingState(Order order)
    {
        this.order = order;
    }
    public OrderStates Cancelled(string description)
    {
        order.CanceledAt = DateTime.UtcNow;
        order.CanceledDescription = description;
        return OrderStates.Cancelled;
    }

    public OrderStates Closed()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Confirmed()
    {
        order.ConfirmedAt = DateTime.UtcNow;
        return OrderStates.Confirmed;
    }

    public OrderStates Delivered()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates InTransit()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Pending()
    {
        throw new NotImplementedException();
    }

    public OrderStates PickupAvailable()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Problem(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Processing()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Returned(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
}
