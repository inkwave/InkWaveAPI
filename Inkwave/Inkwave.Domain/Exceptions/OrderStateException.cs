namespace Inkwave.Domain.Exceptions;

public class OrderStateException : Exception
{
    public OrderStateException() { }
    public OrderStateException(string key) : base($"The order is in the {key} stage")
    {
    }
}
