using Inkwave.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inkwave.Domain;

public class Item : BaseAuditableEntity
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Discount { get; set; }
    public double Tax { get; set; }
    public double Quantity { get; set; }
    public string Image { get; set; } = string.Empty;

    [NotMapped]
    public List<string> Images
    {
        get { return Image.Split(",").ToList(); }
        set { Image = string.Join(",", value); }
    }

    public string Tags { get; set; } = string.Empty;
    public Guid? SubDescriptionId { get; set; }
    public SubDescription? SubDescription { get; set; }
    public ICollection<ItemCategory>? ItemCategorys { get; set; }

}
