using System.ComponentModel.DataAnnotations;

namespace Inkwave.Domain;

public class Category : BaseAuditableEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Guid? CategoryParentId { get; set; }
    public Category? CategoryParent { get; set; }
    public ICollection<ItemCategory>? ItemCategorys { get; set; }

}

