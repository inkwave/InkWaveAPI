namespace Inkwave.Domain;

public class OrderProcessingState : IOrderState
{
    private readonly Order order;
    public OrderProcessingState(Order order)
    {
        this.order = order;
    }
    public OrderStates Cancelled(string description)
    {
        order.CanceledAt = DateTime.Now;
        order.CanceledDescription = description;
        return OrderStates.Cancelled;
    }
    public OrderStates PickupAvailable()
    {
        order.PickupAvailableAt = DateTime.Now;
        return OrderStates.PickupAvailable;
    }

    public OrderStates Problem(string description)
    {
        order.ProblemAt = DateTime.Now;
        order.ProblemDescription = description;
        return OrderStates.Problem;
    }
    public OrderStates Pending()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Confirmed()
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
    public OrderStates Processing()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Returned(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
}
