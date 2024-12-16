using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class BatchIngredientRepository : IBatchIngredientRepository
    {
        private readonly MehmanFoodsDbContext _context;

        public BatchIngredientRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task AddBatchIngredientAsync(BatchIngredient batchIngredient)
        {
            _context.BatchIngredients.Add(batchIngredient);
            await _context.SaveChangesAsync();
        }

        public Task DeleteBatchIngredientAsync(int unit)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BatchIngredient>> GetAllBatchIngredientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BatchIngredient> GetBatchIngredientByIdAsync(int unit)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBatchIngredientAsync(BatchIngredient unit)
        {
            throw new NotImplementedException();
        }
    }
}
