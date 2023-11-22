namespace Inkwave.Application.Features.Categories.Commands.UpdateGategory
{
    public class UpdateGategoryCommand : IRequest<Result<Guid>>
    {

        public UpdateGategoryCommand(Guid? categoryId, string name, string description, string image, Guid? categoryParentId)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Image = image;
            CategoryParentId = categoryParentId;
        }

        public Guid? CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;   
        public Guid? CategoryParentId { get; set; }
    }
}
