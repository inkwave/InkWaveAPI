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


    public static Category Create(string name, string description, string image, Guid? categoryParentId)
    {
        Category category = new Category();
        category.Name = name;
        category.Description = description;
        category.Image = image;
        category.CategoryParentId = categoryParentId;
        return category;
    }

    public Category Update(string name, string description, string image, Guid? categoryParentId)
    {
        this.Name = name;
        this.Description = description;
        this.Image = image;
        this.CategoryParentId = categoryParentId;
        return this;
    }

}

