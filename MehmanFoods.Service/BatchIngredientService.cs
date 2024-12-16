using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class BatchIngredientService : IBatchIngredientService
    {
        public Task AddBatchIngredientAsync(BatchIngredient unit)
        {
            throw new NotImplementedException();
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
