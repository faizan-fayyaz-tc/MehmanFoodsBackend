using MehmanFoods.Core.DTOs.Batch;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IBatchService
    {
        Task AddBatchAsync(BatchCreateDto batchCreateDto);
        Task<Batch> GetBatchByIdAsync(int id);
        Task<IEnumerable<Batch>> GetAllBatchsAsync();
        Task UpdateBatchAsync(Batch unit);
        Task DeleteBatchAsync(int unit);
    }
}
