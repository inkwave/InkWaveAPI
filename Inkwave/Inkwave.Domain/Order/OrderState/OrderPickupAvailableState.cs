namespace Inkwave.Domain;

public class OrderPickupAvailableState : IOrderState
{
    private readonly Order order;
    public OrderPickupAvailableState(Order order)
    {
        this.order = order;
    }
    public OrderStates Processing()
    {
        order.ProcessingAt = DateTime.Now;
        return OrderStates.Processing;
    }

    public OrderStates InTransit()
    {
        order.InTransitAt = DateTime.Now;
        return OrderStates.InTransit;
    }
    public OrderStates Problem(string description)
    {
        order.ProblemAt = DateTime.Now;
        order.ProblemDescription = description;
        return OrderStates.Problem;
    }
    public OrderStates Cancelled(string description)
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



    public OrderStates Pending()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates PickupAvailable()
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }




    public OrderStates Returned(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
}
