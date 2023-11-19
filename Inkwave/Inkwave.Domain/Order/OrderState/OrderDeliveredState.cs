namespace Inkwave.Domain;

public class OrderDeliveredState : IOrderState
{
    private readonly Order order;
    public OrderDeliveredState(Order order)
    {
        this.order = order;
    }
    public OrderStates Closed()
    {
        order.ClosedAt = DateTime.Now;
        return OrderStates.Closed;
    }

    public OrderStates Returned(string description)
    {
        order.ReturnedAt = DateTime.Now;
        order.ReturnedDescription = description;
        return OrderStates.Returned;
    }
    public OrderStates PickupAvailable()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
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

    public OrderStates Problem(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Processing()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

}
