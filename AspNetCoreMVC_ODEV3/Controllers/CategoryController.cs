using AspNetCoreMVC_ODEV3.Models;
using AspNetCoreMVC_ODEV3.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_ODEV3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (_categoryService.CreateCategory(category))
            {
                return RedirectToAction("Index", "Category", _categoryService.GetAllCategories());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if(_categoryService.UpdateCategory(category))
            {
                return RedirectToAction("Index", "Category", _categoryService.GetAllCategories());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if(id > 0)
            {
                var category = _categoryService.GetCategory(id);

                if(category != null)
                {
                    return View(category);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }

        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                

                if(_categoryService.DeleteCategory(id))
                {
                    
                    return RedirectToAction("Index", "Category", _categoryService.GetAllCategories());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }

    }
}
