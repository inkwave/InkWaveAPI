namespace Inkwave.Domain;

public class OrderStateContext
{
    public IOrderState OrderStates { get; internal set; }

    public OrderStateContext(Order order)
    {
        switch (order.OrderStates)
        {
            case Domain.OrderStates.Pending:
                OrderStates = new OrderPendingState(order);
                break;
            case Domain.OrderStates.Confirmed:
                break;
            case Domain.OrderStates.Cancelled:
                break;
            case Domain.OrderStates.Delivered:
                break;
            case Domain.OrderStates.InTransit:
                break;
            case Domain.OrderStates.PickupAvailable:
                break;
            case Domain.OrderStates.Problem:
                break;
            case Domain.OrderStates.Processing:
                break;
            case Domain.OrderStates.Returned:
                break;
            case Domain.OrderStates.Closed:
                break;
            default:
                break;
        }
    }

    public void Cancelled() => OrderStates.Cancelled();

    public void Confirmed() => OrderStates.Confirmed();

    public void Closed() => OrderStates.Closed();

    public void Delivered() => OrderStates.Delivered();

    public void InTransit() => OrderStates.InTransit();

    public void Pending() => OrderStates.Pending();

    public void PickupAvailable() => OrderStates.PickupAvailable();

    public void Problem() => OrderStates.Problem();

    public void Processing() => OrderStates.Processing();

    public void Returned() => OrderStates.Returned();
}
