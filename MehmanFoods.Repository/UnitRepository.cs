using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class UnitRepository : IUnitRepository
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
