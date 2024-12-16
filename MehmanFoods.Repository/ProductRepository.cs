using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MehmanFoodsDbContext _context;

        public ProductRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public Task DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
