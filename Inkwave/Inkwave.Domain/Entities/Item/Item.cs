using Inkwave.Domain.Common;

namespace Inkwave.Domain.Entities;

public class Item : BaseAuditableEntity
{
    public Item()
    {
     
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Image { get; set; }
    public string Tags { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; }
    public DateTime? Deleted { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }

}
