
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

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _bethenysPieShopDbContext.Categories.Include(p => p.Pies)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }
        public async Task<int> AddCategoryAsync(Category category)
        {
            bool categoryWithSameNameExist = await _bethenysPieShopDbContext.Categories.AnyAsync(c => c.Name == category.Name);

            if (categoryWithSameNameExist)
            {
                throw new Exception("A category with the same name already exists");
            }

            _bethenysPieShopDbContext.Categories.Add(category);//could be done using async too

            return await _bethenysPieShopDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateCategoryAsync(Category category)
        {
            bool categoryWithSameNameExist = await _bethenysPieShopDbContext.Categories.AnyAsync(c => c.Name == category.Name && c.CategoryId != category.CategoryId);

            if (categoryWithSameNameExist)
            {
                throw new Exception("A category with the same name already exists");
            }

            var categoryToUpdate = await _bethenysPieShopDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);

            if (categoryToUpdate != null)
            {

                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;

                _bethenysPieShopDbContext.Categories.Update(categoryToUpdate);
                return await _bethenysPieShopDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The category to update can't be found.");
            }
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            var categoryToDetele = await _bethenysPieShopDbContext.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            var piesInCategory =  _bethenysPieShopDbContext.Pies
                .Any(p => p.CategoryId == id);

            if(piesInCategory)
            {
                throw new Exception("Pies exist in this category. Delete all pies in this category before deleting the category.");
            }

            if (categoryToDetele != null)
            {
                _bethenysPieShopDbContext.Categories.Remove(categoryToDetele);
                return await _bethenysPieShopDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The Category to delete can`t be found!");
            }
        }
    }
}
