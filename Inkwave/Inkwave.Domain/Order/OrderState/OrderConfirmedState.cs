namespace Inkwave.Domain;

public class OrderConfirmedState : IOrderState
{
    private readonly Order order;

    public OrderConfirmedState(Order order)
    {
        this.order = order;
    }
    public void Confirmed()
    {
        throw new NotImplementedException();
    }


    public void Cancelled()
    {
        throw new NotImplementedException();
    }

    public void Closed()
    {
        throw new NotImplementedException();
    }


    public void Delivered()
    {
        throw new NotImplementedException();
    }

    public void InTransit()
    {
        throw new NotImplementedException();
    }

    public void Pending()
    {
        throw new NotImplementedException();
    }

    public void PickupAvailable()
    {
        throw new NotImplementedException();
    }

    public void Problem()
    {
        throw new NotImplementedException();
    }

    public void Processing()
    {
        throw new NotImplementedException();
    }

    public void Returned()
    {
        throw new NotImplementedException();
    }
}
