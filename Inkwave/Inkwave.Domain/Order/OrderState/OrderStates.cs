namespace Inkwave.Domain;

public enum OrderStates
{
    Pending,
    Confirmed,
    Cancelled,
    Processing,
    PickupAvailable,
    InTransit,
    Delivered,
    Problem,
    Returned,
    Closed
}