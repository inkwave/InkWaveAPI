namespace Inkwave.Domain;

public class OrderClosedState : IOrderState
{
    private readonly Order order;

    public OrderClosedState(Order order)
    {
        this.order = order;
    }
    public OrderStates Confirmed()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }


    public OrderStates Cancelled(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
    public OrderStates Processing()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
    public OrderStates Pending()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
    public OrderStates Closed()
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


    public OrderStates PickupAvailable()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Problem(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }


    public OrderStates Returned(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
}
