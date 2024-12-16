using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class BatchIngredient
    {
        public int BatchIngredientId { get; set; }
        public int BatchId { get; set; } 
        public Batch Batch { get; set; }

        public int IngredientId { get; set; } 
        public Ingredient Ingredient { get; set; }

        public int UnitId { get; set; } 
        public Unit Unit { get; set; } 

        public decimal QuantityUsed { get; set; } 
        public decimal PriceUsed { get; set; } 
    }
}
