using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Entity;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;
        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
           var result = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public  bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.Where(p=>p.ProductId== id).FirstOrDefault();
            var result = _dbContext.Products.Remove(product);
             _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<Product> EditProduct(Product product)
        {
            var entity = await GetProductById(product.ProductId);
            if (entity != null) {
                var result = _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            return entity;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> Products()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
