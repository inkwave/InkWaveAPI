namespace Inkwave.Domain;

public interface IOrderState
{
    OrderStates Pending();
    OrderStates Confirmed();
    OrderStates Cancelled(string description);
    OrderStates Delivered();
    OrderStates InTransit();
    OrderStates PickupAvailable();
    OrderStates Problem(string description);
    OrderStates Processing();
    OrderStates Returned(string description);
    OrderStates Closed();
}
