using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class UnitService : IUnitService
    {
        public Task AddUnitAsync(Unit unit)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUnitAsync(int unit)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Unit>> GetAllUnitsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Unit> GetIngredientByIdAsync(int unit)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUnitAsync(Unit unit)
        {
            throw new NotImplementedException();
        }
    }
}
