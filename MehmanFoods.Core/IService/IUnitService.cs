using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IUnitService
    {
        Task AddUnitAsync(Unit unit);
        Task<Unit> GetIngredientByIdAsync(int unit);
        Task<IEnumerable<Unit>> GetAllUnitsAsync();
        Task UpdateUnitAsync(Unit unit);
        Task DeleteUnitAsync(int unit);
    }
}
