namespace Inkwave.Domain;

public class OrderInTransitState : IOrderState
{
    private readonly Order order;
    public OrderInTransitState(Order order)
    {
        this.order = order;
    }
    public OrderStates PickupAvailable()
    {
        order.PickupAvailableAt = DateTime.Now;
        return OrderStates.PickupAvailable;
    }
    public OrderStates Delivered()
    {
        order.DeliveredAt = DateTime.Now;
        return OrderStates.Delivered;
    }
    public OrderStates Problem(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }

    public OrderStates Cancelled(string description)
    {
        throw new OrderStateException(this.order.OrderStates.ToString());
    }
    public OrderStates InTransit()
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



    public OrderStates Pending()
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
