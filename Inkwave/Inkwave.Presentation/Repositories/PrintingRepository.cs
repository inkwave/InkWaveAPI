using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    internal class PrintingRepository : IPrintingRepository
    {


        readonly IGenericRepository<Printing> genericRepository;
        public PrintingRepository(IGenericRepository<Printing> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<Printing> CreatePrintingAsync(Guid userId, string file, string bindingOption, string printingColor, string paperSize, string paperType, string printingLayou, string printingSide, string coverImage, string coverBgSize, string coverPositionX, string coverPositionY, string coverRepeat, string coverZoom)
        {
            Printing printing = Printing.Create(userId, file, bindingOption, printingColor, paperSize, paperType, printingLayou, printingSide, coverImage, coverBgSize, coverPositionX, coverPositionY, coverRepeat, coverZoom);
            await genericRepository.AddAsync(printing);
            return printing;
        }

        public async Task<IEnumerable<Printing>> GetAllPrintingsAsync()
        {
            return await genericRepository.GetAllAsync();
        }

        public Task<Printing> GetPrintingByIdAsync(Guid id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Printing>> GetPrintingByUserIdAsync(Guid userId)
        {
            return await genericRepository.Entities.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task RemovePrintingAsync(Guid id)
        {
            Printing printing = await genericRepository.GetByIdAsync(id);
            if (printing != null)
                await genericRepository.DeleteAsync(printing);
        }

        public async Task UpdatePrintingAsync(Guid id, string file, string bindingOption, string printingColor, string paperSize, string paperType, string printingLayou, string printingSide, string coverImage, string coverBgSize, string coverPositionX, string coverPositionY, string coverRepeat, string coverZoom)
        {
            Printing printing = await genericRepository.GetByIdAsync(id);
            if (printing != null)
            {
                printing.Update(file, bindingOption, printingColor, paperSize, paperType, printingLayou, printingSide, coverImage, coverBgSize, coverPositionX, coverPositionY, coverRepeat, coverZoom);
                await genericRepository.UpdateAsync(printing);
            }
        }
    }
}
