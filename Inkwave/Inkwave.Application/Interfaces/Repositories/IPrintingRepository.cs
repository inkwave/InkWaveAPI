namespace Inkwave.Application.Interfaces.Repositories;

public interface IPrintingRepository
{
    Task<Printing> CreatePrintingAsync(Guid userId, string file,
        string bindingOption, string printingColor, string paperSize, string paperType, string printingLayou, string printingSide,
        string coverImage, string coverBgSize, string coverPositionX, string coverPositionY, string coverRepeat, string coverZoom);
    Task<IEnumerable<Printing>> GetAllPrintingsAsync();
    Task<Printing> GetPrintingByIdAsync(Guid id);
    Task<IEnumerable<Printing>> GetPrintingByUserIdAsync(Guid userId);
    Task RemovePrintingAsync(Guid id);
    Task UpdatePrintingAsync(Guid id, string file,
        string bindingOption, string printingColor, string paperSize, string paperType, string printingLayou, string printingSide,
        string coverImage, string coverBgSize, string coverPositionX, string coverPositionY, string coverRepeat, string coverZoom);
}
