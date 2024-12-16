using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class IngredientService : IIngredientService
    {
        public Task AddIngredientAsync(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIngredientAsync(int ingredient)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredientByIdAsync(int ingredient)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIngredientAsync(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
