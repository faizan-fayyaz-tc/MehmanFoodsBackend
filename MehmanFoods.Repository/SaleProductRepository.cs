using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class SaleProductRepository : ISaleProductRepository
    {
        public Task AddProductToSaleAsync(int saleId, int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsBySaleIdAsync(int saleId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromSaleAsync(int saleId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductInSaleAsync(int saleId, int productId, int newQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
