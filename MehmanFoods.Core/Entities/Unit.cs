using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class Unit
    {
        public int UnitId { get; set; } // Primary Key
        public string UnitName { get; set; } // e.g., "Kilogram", "Gram", "Liter"
        public string Abbreviation { get; set; } // e.g., "kg", "g", "l"
    }
}
