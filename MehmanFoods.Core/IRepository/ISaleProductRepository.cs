using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface ISaleProductRepository
    {
        Task AddProductToSaleAsync(int saleId, int productId, int quantity);
        Task<IEnumerable<Product>> GetProductsBySaleIdAsync(int saleId);
        Task RemoveProductFromSaleAsync(int saleId, int productId);
        Task UpdateProductInSaleAsync(int saleId, int productId, int newQuantity);
    }
}
