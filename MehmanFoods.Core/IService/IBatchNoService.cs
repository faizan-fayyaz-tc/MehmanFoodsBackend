using MehmanFoods.Core.DTOs.Invoice;
using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IBatchNoService
    {
        Task<IEnumerable<BatchNo>> GetBatchNosByProductIdAsync(int productId);
        Task AddBatchNoAsync(BatchNo batchNo);
        Task<BatchNo> GetLastBatchNoByProductIdAsync(int productId);
    }
}
