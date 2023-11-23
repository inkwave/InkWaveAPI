namespace Inkwave.Application.Features.Categories.Commands.UpdateCategory;


public class UpdateCategoryCommand : IRequest<Result<Category>>
{

    public UpdateCategoryCommand(Guid id, string name, string description, string image, Guid? categoryParentId)
    {
        Id = id;
        Name = name;
        Description = description;
        Image = image;
        CategoryParentId = categoryParentId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Guid? CategoryParentId { get; set; }
}
