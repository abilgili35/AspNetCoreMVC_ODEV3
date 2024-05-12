using AspNetCoreMVC_ODEV3.Models;

namespace AspNetCoreMVC_ODEV3.Repository
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        bool DeleteCategory(int id);
        bool UpdateCategory(Category category);
        bool CreateCategory(Category category);
    }
}
