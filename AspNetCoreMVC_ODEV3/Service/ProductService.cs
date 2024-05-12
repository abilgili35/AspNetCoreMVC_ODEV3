using AspNetCoreMVC_ODEV3.Models;
using AspNetCoreMVC_ODEV3.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AspNetCoreMVC_ODEV3.Service
{
    public class ProductService : IProductService
    {
        NorthwindContext _context = new NorthwindContext();

        public bool CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);

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

        public bool DeleteProduct(int id)
        {
            try
            {
                Product product = GetProduct(id);

                if (product != null)
                {
                    _context.Products.Remove(product);
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

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public bool UpdateProduct(Product updated)
        {
            try
            {
                Product product = _context.Products.FirstOrDefault(x => x.ProductId == updated.ProductId);

                if (product != null)
                {
                    product.ProductName = updated.ProductName;
                    product.UnitPrice = updated.UnitPrice;
                    product.UnitsInStock = updated.UnitsInStock;

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
    }
}
