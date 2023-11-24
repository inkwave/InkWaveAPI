namespace Inkwave.Application.Features.Prints.Commands.AddPrinting;

public class AddPrintingCommand : IRequest<Result<Guid>>
{
    public Guid UserId { get; set; }
    public string File { get; set; } = string.Empty;
    public string BindingOption { get; set; } = string.Empty;
    public string PrintingColor { get; set; } = string.Empty;
    public string PaperSize { get; set; } = string.Empty;
    public string PaperType { get; set; } = string.Empty;
    public string PrintingLayout { get; set; } = string.Empty;
    public string PrintingSide { get; set; } = string.Empty;
    public string CoverImage { get; set; } = string.Empty;
    public string CoverBgSize { get; set; } = string.Empty;
    public string CoverPositionX { get; set; } = string.Empty;
    public string CoverPositionY { get; set; } = string.Empty;
    public string CoverRepeat { get; set; } = string.Empty;
    public string CoverZoom { get; set; } = string.Empty;

}
