namespace Inkwave.Application.Features.Orders.Queries.GetOrdersById;

public class GetPrintingByIdDto : IMapFrom<Printing>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public string File { get; set; }
    public string BindingOption { get; set; }
    public string PrintingColor { get; set; }
    public string PaperSize { get; set; }
    public string PaperType { get; set; }
    public string PrintingLayout { get; set; }
    public string PrintingSide { get; set; }
    public string CoverImage { get; set; }
    public string CoverBgSize { get; set; }
    public string CoverPositionX { get; set; }
    public string CoverPositionY { get; set; }
    public string CoverRepeat { get; set; }
    public string CoverZoom { get; set; }
}