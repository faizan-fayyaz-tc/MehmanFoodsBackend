using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}
