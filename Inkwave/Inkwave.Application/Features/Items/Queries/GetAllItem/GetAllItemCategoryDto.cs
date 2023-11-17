using Inkwave.Application.Common.Mappings;

namespace Inkwave.Application.Features.Items.Queries.GetAllItem
{
    public class GetAllItemCategoryDto : IMapFrom<Category>
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
