using AspNetCoreMVC_ODEV3.Models;
using AspNetCoreMVC_ODEV3.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AspNetCoreMVC_ODEV3.Service
{
    public class CategoryService : ICategoryService
    {
        NorthwindContext _context = new NorthwindContext();

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public bool DeleteCategory(int id)
        {

            try
            {
                Category category = GetCategory(id);

                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public bool UpdateCategory(Category updated)
        {
            try
            {
                Category category = _context.Categories.FirstOrDefault(x => x.CategoryId == updated.CategoryId);

                if (category != null)
                {
                    category.CategoryName = updated.CategoryName;
                    category.Description = updated.Description;
                    category.Picture = updated.Picture;

                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);

                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
