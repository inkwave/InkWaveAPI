namespace Inkwave.Domain;

public enum OrderStatus
{
    Pending,
    Cancelled,
    Delivered,
    InTransit,
    PickupAvailable,
    Problem,
    Processing,
    Returned,
    Closed
}

