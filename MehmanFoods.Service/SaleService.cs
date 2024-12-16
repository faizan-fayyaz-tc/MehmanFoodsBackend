using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class SaleService : ISaleService
    {
        public Task AddSaleAsync(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSaleAsync(int saleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetSaleByIdAsync(int saleId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSaleAsync(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
