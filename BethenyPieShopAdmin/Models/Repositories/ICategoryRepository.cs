namespace BethenyPieShopAdmin.Models.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}