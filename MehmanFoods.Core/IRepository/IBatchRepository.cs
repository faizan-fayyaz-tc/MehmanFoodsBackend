using MehmanFoods.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface IBatchRepository
    {
        Task AddBatchAsync(Batch unit);
        Task<Batch> GetBatchByIdAsync(int unit);
        Task<IEnumerable<Batch>> GetAllBatchsAsync();
        Task UpdateBatchAsync(Batch unit);
        Task DeleteBatchAsync(int unit);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
