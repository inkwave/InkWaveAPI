namespace Inkwave.Domain;

public interface IOrderState
{
    void Pending();
    void Confirmed();
    void Cancelled();
    void Delivered();
    void InTransit();
    void PickupAvailable();
    void Problem();
    void Processing();
    void Returned();
    void Closed();
}
