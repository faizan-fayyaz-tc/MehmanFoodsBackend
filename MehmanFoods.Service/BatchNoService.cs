using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class BatchNoService : IBatchNoService
    {
        public Task AddBatchNoAsync(BatchNo batchNo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BatchNo>> GetBatchNosByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<BatchNo> GetLastBatchNoByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
