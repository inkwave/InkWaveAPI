namespace Inkwave.Domain;

public class OrderStateContext
{
    public IOrderState _orderStates { get; internal set; }
    public Order _order { get; internal set; }

    public OrderStateContext(Order order)
    {
        _order = order;
        switch (order.OrderStates)
        {
            case Domain.OrderStates.Pending:
                _orderStates = new OrderPendingState(order);
                break;
            case Domain.OrderStates.Confirmed:
                _orderStates = new OrderConfirmedState(order);
                break;
            case Domain.OrderStates.Cancelled:
                _orderStates = new OrderCancelledState(order);
                break;
            case Domain.OrderStates.Delivered:
                _orderStates = new OrderDeliveredState(order);
                break;
            case Domain.OrderStates.InTransit:
                _orderStates = new OrderInTransitState(order);
                break;
            case Domain.OrderStates.PickupAvailable:
                _orderStates = new OrderPickupAvailableState(order);
                break;
            case Domain.OrderStates.Problem:
                _orderStates = new OrderProblemState(order);
                break;
            case Domain.OrderStates.Processing:
                _orderStates = new OrderProcessingState(order);
                break;
            case Domain.OrderStates.Returned:
                _orderStates = new OrderReturnedState(order);
                break;
            case Domain.OrderStates.Closed:
                _orderStates = new OrderClosedState(order);
                break;
            default:
                break;
        }
    }

    public void Cancelled(string description) => _order.OrderStates = _orderStates.Cancelled(description);

    public void Confirmed() => _order.OrderStates = _orderStates.Confirmed();

    public void Closed() => _order.OrderStates = _orderStates.Closed();

    public void Delivered() => _order.OrderStates = _orderStates.Delivered();

    public void InTransit() => _order.OrderStates = _orderStates.InTransit();

    public void Pending() => _order.OrderStates = _orderStates.Pending();

    public void PickupAvailable() => _order.OrderStates = _orderStates.PickupAvailable();

    public void Problem(string description) => _order.OrderStates = _orderStates.Problem(description);

    public void Processing() => _order.OrderStates = _orderStates.Processing();

    public void Returned(string description) => _order.OrderStates = _orderStates.Returned(description);
}
