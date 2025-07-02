
using Microsoft.EntityFrameworkCore;

namespace BethenyPieShopAdmin.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethenysPieShopDbContext _bethenysPieShopDbContext;

        public CategoryRepository(BethenysPieShopDbContext bethenysPieShopDbContext)
        {
            _bethenysPieShopDbContext = bethenysPieShopDbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _bethenysPieShopDbContext.Categories.OrderBy(p => p.CategoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _bethenysPieShopDbContext.Categories
                .OrderBy(c => c.CategoryId).ToListAsync();
        }
    }
}
