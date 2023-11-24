namespace Inkwave.Domain;
public class Printing : BaseAuditableEntity
{
    public Printing()
    {

    }
    private Printing(Guid userId, string file, string bindingOption, string printingColor, string paperSize, string paperType, string printingLayou, string printingSide,
           string coverImage, string coverBgSize, string coverPositionX, string coverPositionY, string coverRepeat, string coverZoom)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        File = file;
        BindingOption = bindingOption;
        PrintingColor = printingColor;
        PaperSize = paperSize;
        PaperType = paperType;
        PrintingLayout = printingLayou;
        PrintingSide = printingSide;
        CoverImage = coverImage;
        CoverBgSize = coverBgSize;
        CoverPositionX = coverPositionX;
        CoverPositionY = coverPositionY;
        CoverRepeat = coverRepeat;
        CoverZoom = coverZoom;
    }
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
    public static Printing Create(Guid userId, string file,
        string bindingOption, string printingColor, string paperSize, string paperType, string printingLayou, string printingSide,
        string coverImage, string coverBgSize, string coverPositionX, string coverPositionY, string coverRepeat, string coverZoom)
    {
        Printing printing = new Printing(userId, file, bindingOption, printingColor, paperSize, paperType, printingLayou, printingSide, coverImage, coverBgSize, coverPositionX, coverPositionY, coverRepeat, coverZoom);
        return printing;
    }
    public Printing Update(string file,
        string bindingOption, string printingColor, string paperSize, string paperType, string printingLayou, string printingSide,
        string coverImage, string coverBgSize, string coverPositionX, string coverPositionY, string coverRepeat, string coverZoom)
    {
        this.File = file;
        this.BindingOption = bindingOption;
        this.PrintingColor = printingColor;
        this.PaperSize = paperSize;
        this.PaperType = paperType;
        this.PrintingLayout = printingLayou;
        this.PrintingSide = printingSide;
        this.CoverImage = coverImage;
        this.CoverBgSize = coverBgSize;
        this.CoverPositionX = coverPositionX;
        this.CoverPositionY = coverPositionY;
        this.CoverRepeat = coverRepeat;
        this.CoverZoom = coverZoom;
        return this;
    }
}