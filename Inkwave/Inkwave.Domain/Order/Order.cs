using Inkwave.Domain.Common;

namespace Inkwave.Domain;


public class Order : BaseAuditableEntity
{
    public readonly OrderStateContext OrderStateContext;
    private Order()
    {
        OrderStateContext = new OrderStateContext(this);
    }
    public OrderStates OrderStates { get; set; } = OrderStates.Pending;
    public PaymentStatus PaymentStatus { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BillingAddressId { get; set; }
    public Guid ShippingAddressId { get; set; }
    public double TotalPrice { get; set; }
    public double TotalDiscount { get; set; }
    public double TotalTax { get; set; }
    public double TotalNet { get; set; }
    public DateTime Canceled_at { get; set; }
    ICollection<OrderLine> _orderLines = new HashSet<OrderLine>();

    public static Order Create(Guid customerId, Guid billingAddressId, Guid shippingAddressId, double price, double discount, double tax, double net)
    {
        Order order = new Order();
        order.CreatedDate = DateTime.Now;
        order.Id = Guid.NewGuid();
        order.CustomerId = customerId;
        order.BillingAddressId = billingAddressId;
        order.ShippingAddressId = shippingAddressId;
        order.TotalPrice = price;
        order.TotalDiscount = discount;
        order.TotalTax = tax;
        order.TotalNet = net;
        return order;
    }
    public OrderLine SetOrderLine(Guid itemId, double quantity, double price, double discount, double tax)
    {
        var orderLine = OrderLine.Create(Id, itemId, quantity, price, discount, tax);
        _orderLines.Add(orderLine);
        return orderLine;
    }
    public IReadOnlyCollection<OrderLine> GetOrderLines()
    {
        return _orderLines.ToList();
    }
}
