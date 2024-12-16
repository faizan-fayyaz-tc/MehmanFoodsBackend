using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface IBatchNoRepository
    {
        Task<IEnumerable<BatchNo>> GetBatchNosByProductIdAsync(int productId);
        Task AddBatchNoAsync(BatchNo batchNo);
        Task<BatchNo> GetLastBatchNoByProductIdAsync(int productId);
    }
}
