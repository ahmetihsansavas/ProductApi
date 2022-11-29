using ProductAPI.Entity;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> Products();
        public Task<Product> CreateProduct(Product product);
        public Task<Product> EditProduct (Product product);
        public bool DeleteProduct (int id);
        public Task<Product> GetProductById(int id);
    }
}
