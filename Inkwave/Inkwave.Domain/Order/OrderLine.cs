using Inkwave.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain;

public class OrderLine : BaseEntity
{
    [Required]
    public Guid OrderId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    [Range(0.1, double.MaxValue)]
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
    public double Net { get; set; }
    public OrderLine(Guid orderId, Guid itemId, double quantity,
        double price,
        double discount,
        double tax)
    {
        this.Id = Guid.NewGuid();
        this.ItemId = itemId;
        this.OrderId = orderId;
        this.Quantity = quantity;
        this.Price = price;
        this.Discount = discount;
        this.Tax = tax;
        this.Total = Quantity * Price;
        this.Net = (Total - Discount) + Tax;

    }
    public static OrderLine Create(Guid orderId, Guid itemId, double quantity,
        double price,
        double discount,
        double tax)
    {
        return new OrderLine(orderId, itemId, quantity, price, discount, tax);
    }
}