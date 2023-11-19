namespace Inkwave.Domain;

public class OrderConfirmedState : IOrderState
{
    private readonly Order order;

    public OrderConfirmedState(Order order)
    {
        this.order = order;
    }
    public OrderStates Confirmed()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }


    public OrderStates Cancelled(string description)
    {
        order.CanceledAt = DateTime.Now;
        order.CanceledDescription = description;
        return OrderStates.Cancelled;
    }
    public OrderStates Processing()
    {
        order.ProblemAt = DateTime.Now;
        return OrderStates.Problem;
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
