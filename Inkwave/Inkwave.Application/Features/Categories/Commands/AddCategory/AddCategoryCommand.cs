namespace Inkwave.Application.Features.Categories.Commands.AddCategory;

public class AddCategoryCommand : IRequest<Result<Category>>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Guid? CategoryParentId { get; set; }


    public AddCategoryCommand(string name, string description, string image, Guid? categoryParentId)
    {
        Name = name;
        Description = description;
        Image = image;
        CategoryParentId = categoryParentId;
    }


}
