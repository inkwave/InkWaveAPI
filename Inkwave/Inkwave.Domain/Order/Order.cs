namespace Inkwave.Domain;
public class Order : BaseAuditableEntity
{
    private Order()
    {
    }
    public OrderStateContext OrderStateContext => new OrderStateContext(this);
    public OrderStates OrderStates { get; internal set; }

    public PaymentStatus PaymentStatus { get; set; }
    public User Customer { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AddressId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public bool IsCashOnDelivery { get; set; }
    public double TotalPrice { get; set; }
    public double TotalDiscount { get; set; }
    public double TotalTax { get; set; }
    public double TotalNet { get; set; }

    public DateTime? ConfirmedAt { get; set; }
    public DateTime? CanceledAt { get; set; }
    public string CanceledDescription { get; set; }
    public DateTime? ProcessingAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime? InTransitAt { get; set; }
    public DateTime? PickupAvailableAt { get; set; }
    public DateTime? ProblemAt { get; set; }
    public string ProblemDescription { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public string ReturnedDescription { get; set; }
    public DateTime? ClosedAt { get; set; }


    ICollection<OrderLine> _orderLines = new HashSet<OrderLine>();
    public static Order Create(Guid customerId, Guid addressId, Guid paymentMethodId, bool isCashOnDelivery, double price, double discount, double tax, double net)
    {
        Order order = new Order();
        order.CreatedDate = DateTime.Now;
        order.Id = Guid.NewGuid();
        order.CustomerId = customerId;
        order.AddressId = addressId;
        order.PaymentMethodId = paymentMethodId;
        order.IsCashOnDelivery = isCashOnDelivery;
        order.TotalPrice = price;
        order.TotalDiscount = discount;
        order.TotalTax = tax;
        order.TotalNet = net;
        order.AddDomainEvent(new CreatedOrderEvent(order));
        return order;
    }
    public OrderLine SetOrderLine(Guid itemId, string itemName, double quantity, double price, double discount, double tax)
    {
        var orderLine = OrderLine.Create(Id, itemId, itemName, quantity, price, discount, tax);
        _orderLines.Add(orderLine);
        return orderLine;
    }
    public void SetOrdersLine(params OrderLine[] orderLines)
    {
        foreach (var orderLine in orderLines)
            _orderLines.Add(orderLine);
    }
    public IReadOnlyCollection<OrderLine> GetOrderLines()
    {
        return _orderLines.ToList();
    }


}