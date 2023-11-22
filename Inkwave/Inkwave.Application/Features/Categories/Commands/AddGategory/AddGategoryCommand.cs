namespace Inkwave.Application.Features.Categories.Commands.AddGategory
{
    public class AddGategoryCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public Guid? CategoryParentId { get; set; }

        public Guid? CategoryId { get; set;}

       

        public AddGategoryCommand(Guid? categoryId, string name, string description, string image, Guid? categoryParentId)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Image = image;
            CategoryParentId = categoryParentId;
        }


    }
}
