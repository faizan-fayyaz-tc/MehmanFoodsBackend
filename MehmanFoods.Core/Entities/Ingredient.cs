using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public DateTime AddedAt { get; set; }
        public int DefaultUnitId { get; set; } // Foreign key to Unit
        public Unit DefaultUnit { get; set; } // Navigation property
        public ICollection<BatchIngredient> BatchIngredients { get; set; }
    }
}
