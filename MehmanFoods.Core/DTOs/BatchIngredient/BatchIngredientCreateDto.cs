using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.DTOs.BatchIngredient
{
    public class BatchIngredientCreateDto
    {
        public int IngredientId { get; set; }  
        public decimal QuantityUsed { get; set; }  
        public int UnitId { get; set; }  
        public decimal PriceUsed { get; set; }  
    }
}
