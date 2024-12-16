using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IBatchIngredientService
    {
        Task AddBatchIngredientAsync(BatchIngredient unit);
        Task<BatchIngredient> GetBatchIngredientByIdAsync(int unit);
        Task<IEnumerable<BatchIngredient>> GetAllBatchIngredientsAsync();
        Task UpdateBatchIngredientAsync(BatchIngredient unit);
        Task DeleteBatchIngredientAsync(int unit);
    }
}
