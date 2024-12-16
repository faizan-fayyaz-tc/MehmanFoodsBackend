using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface ISaleRepository
    {
        Task AddSaleAsync(Sale sale);
        Task<Sale> GetSaleByIdAsync(int saleId);
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task UpdateSaleAsync(Sale sale);
        Task DeleteSaleAsync(int saleId);
    }
}
