namespace Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdDto : IMapFrom<Order>
{
    public string OrderStates { get; set; }
    public string PaymentStatus { get; set; }
    public string Customer { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AddressId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public bool IsCashOnDelivery { get; set; }
    public double TotalPrice { get; set; }
    public double TotalDiscount { get; set; }
    public double TotalTax { get; set; }
    public double TotalNet { get; set; }
    public DateTime? CanceledAt { get; set; }
    public IReadOnlyCollection<OrderLineDto> Items { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Order, GetOrdersByUserIdDto>()
                .ForMember(d => d.OrderStates, opt => opt.MapFrom(s => s.OrderStates.ToString()))
                .ForMember(d => d.Customer, opt => opt.MapFrom(s => s.Customer.FirstName))
                .ForMember(d => d.Items, opt => opt.MapFrom(s => s.GetOrderLines()))
                .ForMember(d => d.PaymentStatus, opt => opt.MapFrom(s => s.PaymentStatus.ToString()));

        }
    }
}
public class OrderLineDto : IMapFrom<OrderLine>
{
    public Guid OrderId { get; set; }
    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
    public double Net { get; set; }

}
