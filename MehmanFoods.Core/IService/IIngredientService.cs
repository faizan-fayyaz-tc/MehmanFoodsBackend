using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IIngredientService
    {
        Task AddIngredientAsync(Ingredient ingredient);
        Task<Ingredient> GetIngredientByIdAsync(int ingredient);
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
        Task UpdateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(int ingredient);
    }
}
