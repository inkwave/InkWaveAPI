namespace Inkwave.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdCategoryDto : IMapFrom<Category>
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
