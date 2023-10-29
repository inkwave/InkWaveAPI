using Inkwave.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain.Entities;

public class Item : BaseAuditableEntity
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public double Discount { get; set; }
    public double Tax { get; set; }
    public double Price { get; set; }
    public double Quantity { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public SubDescription SubDescription { get; set; } = new SubDescription();
    public string Tags { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

}
