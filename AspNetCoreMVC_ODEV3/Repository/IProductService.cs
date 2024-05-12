using AspNetCoreMVC_ODEV3.Models;

namespace AspNetCoreMVC_ODEV3.Repository
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        bool DeleteProduct(int id);
        Product GetProduct(int id);
        bool UpdateProduct(Product product);
        bool CreateProduct(Product product);
    }
}
