namespace Inkwave.Domain;

public enum OrderStates
{
    Pending,
    Confirmed,
    Cancelled,
    Delivered,
    InTransit,
    PickupAvailable,
    Problem,
    Processing,
    Returned,
    Closed
}