using Inkwave.Application.Common.Mappings;
using Inkwave.Domain.Item;

namespace Inkwave.Application.Features.Carts.Queries.GetCartInfo;

public class GetCartInfoDto
{
    public ICollection<GetItemsMyCartDto> Items { get; set; } = new HashSet<GetItemsMyCartDto>();

    public double SubTotal => Items.Sum(x => x.SubTotal);
    public double Discount => Items.Sum(x => x.Discount);
    public double Tax => Items.Sum(x => x.Tax * x.Quantity);
    public int ItemCount => Items.Count;
    public double Shipping => 20;
    public double Total => (SubTotal - Discount) + Tax + Shipping;

}

public class GetItemsMyCartDto : IMapFrom<Item>
{
    public Guid Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Quantity { get; set; }
    public double SubTotal => Price * Quantity;
    public double Discount { get; set; }
    public double Tax { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;

}