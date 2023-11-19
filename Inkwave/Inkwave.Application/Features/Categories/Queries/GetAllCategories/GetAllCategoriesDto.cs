namespace Inkwave.Application.Features.Categorys.Queries
{
    public class GetAllCategoriesDto : IMapFrom<Category>
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
