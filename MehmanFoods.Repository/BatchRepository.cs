using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class BatchRepository : IBatchRepository
    {
        private readonly MehmanFoodsDbContext _context;

        public BatchRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task AddBatchAsync(Batch batch)
        {
            _context.Batches.AddAsync(batch);
            await _context.SaveChangesAsync();
        }

        public Task DeleteBatchAsync(int batch)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Batch>> GetAllBatchsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Batch> GetBatchByIdAsync(int id)
        {
            return await _context.Batches.FindAsync(id);
        }

        public Task UpdateBatchAsync(Batch batch)
        {
            throw new NotImplementedException();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
