namespace Inkwave.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdDto : IMapFrom<Item>
    {
        public Guid Id { get; init; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Quantity { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public double Rate => new Random().Next(1, 5) + new Random().NextDouble() - 0.1;
        public GetItemByIdSubDescriptionDto? SubDescription { get; set; }
        public ICollection<GetItemByIdCategoryDto> Categorys { get; set; } = new HashSet<GetItemByIdCategoryDto>();
    }
}
