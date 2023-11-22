using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Inkwave.Persistence.Repositories
{
    public class GategoryRepository : IGategoryRepository
    {

        readonly IGenericRepository<Category> genericRepository;

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var gategory = Category.Create(category.Name, category.Description, category.Image, category.CategoryParentId);
            await genericRepository.AddAsync(gategory);
            return gategory;

        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var model = await genericRepository.GetByIdAsync(category.Id);
            model.Update(category.Name, category.Description, category.Image, category.CategoryParentId);
            await genericRepository.UpdateAsync(model);
            return model;
        }


        
    }
    
}
