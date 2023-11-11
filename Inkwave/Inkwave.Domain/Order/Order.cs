using Inkwave.Domain.Common;

namespace Inkwave.Domain;


public class Order : BaseAuditableEntity
{
    public readonly OrderStateContext OrderStateContext;
    public Order()
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
    public ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();


}
