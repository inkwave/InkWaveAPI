using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain;

public class Cart : BaseEntity
{
    private Cart(Guid UserId, Guid ItemId, double Quantity)
    {
        this.Id = Guid.NewGuid();
        this.UserId = UserId;
        this.ItemId = ItemId;
        this.Quantity = Quantity;
    }
    public static Cart Create(Guid UserId, Guid ItemId, double Quantity)
    {
        return new Cart(UserId, ItemId, Quantity);
    }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    [Range(0.1, double.MaxValue)]
    public double Quantity { get; set; }
}
