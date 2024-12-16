using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class Batch
    {
        public int BatchId { get; set; }  
        public string BatchCode { get; set; }  
        public int Quantity { get; set; }  
        public DateTime ProductionDate { get; set; } 
        public decimal ExpectedSales { get; set; }  
        public decimal ExpectedProfitPercentage { get; set; }  

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<BatchIngredient> BatchIngredients { get; set; }
    }
}
