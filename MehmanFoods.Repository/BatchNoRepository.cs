using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class BatchNoRepository : IBatchNoRepository
    {
        private readonly MehmanFoodsDbContext _context;

        public BatchNoRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task AddBatchNoAsync(BatchNo batchNo)
        {
            await _context.BatchesNo.AddAsync(batchNo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BatchNo>> GetBatchNosByProductIdAsync(int productId)
        {
            return await _context.BatchesNo
                .Where(b=>b.ProductId == productId)
                .ToListAsync();
        }

        public async Task<BatchNo> GetLastBatchNoByProductIdAsync(int productId)
        {
            return await _context.BatchesNo
                .Where(b => b.ProductId == productId)
                .OrderByDescending(b => b.BatchNumber)
                .FirstOrDefaultAsync();
        }
    }
}
