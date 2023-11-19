namespace Inkwave.Domain;

public class OrderReturnedState : IOrderState
{
    private readonly Order order;
    public OrderReturnedState(Order order)
    {
        this.order = order;
    }
    public OrderStates Closed()
    {
        order.ClosedAt = DateTime.Now;
        return OrderStates.Closed;
    }
    public OrderStates Cancelled(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
    public OrderStates Confirmed()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
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
        throw new OrderStateException(this.order.OrderStates.ToString());
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
