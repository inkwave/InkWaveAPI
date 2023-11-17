using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain;

public class OrderLine : BaseEntity
{
    [Required]
    public Guid OrderId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    [Range(0.1, double.MaxValue)]
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
    public double Net { get; set; }
    public OrderLine(Guid orderId, Guid itemId, string itemName, double quantity, double price, double discount, double tax)
    {
        this.Id = Guid.NewGuid();
        this.OrderId = orderId;
        this.ItemId = itemId;
        this.ItemName = itemName;
        this.Quantity = quantity;
        this.Price = price;
        this.Discount = discount;
        this.Tax = tax;
        this.Total = Quantity * Price;
        this.Net = (Total - Discount) + Tax;

    }
    public static OrderLine Create(Guid orderId, Guid itemId, string itemName, double quantity,
        double price,
        double discount,
        double tax)
    {
        return new OrderLine(orderId, itemId, itemName, quantity, price, discount, tax);
    }
}