using AspNetCoreMVC_ODEV3.Models;
using AspNetCoreMVC_ODEV3.Repository;
using AspNetCoreMVC_ODEV3.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_ODEV3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAllProducts());
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {


                if (_productService.DeleteProduct(id))
                {

                    return RedirectToAction("Index", "Product", _productService.GetAllProducts());
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                var product = _productService.GetProduct(id);

                if (product != null)
                {
                    return View(product);
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

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (_productService.UpdateProduct(product))
            {
                return RedirectToAction("Index", "Product", _productService.GetAllProducts());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (_productService.CreateProduct(product))
            {
                return RedirectToAction("Index", "Product", _productService.GetAllProducts());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
