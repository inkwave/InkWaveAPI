using Inkwave.Application.Common.Mappings;

namespace Inkwave.Application.Features.Favourites.Queries.GetMyFavourite;

public class GetMyFavouriteDto : IMapFrom<Item>
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

}
