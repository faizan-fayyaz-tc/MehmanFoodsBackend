using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IProductService
    {
        Task AddProductAsync(ProductCreateDto productCreateDto);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int productId);
    }
}
