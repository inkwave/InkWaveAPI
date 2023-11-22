using Inkwave.Domain;
namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IGategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        

        
    }
}
