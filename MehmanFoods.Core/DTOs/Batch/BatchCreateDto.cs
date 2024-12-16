using MehmanFoods.Core.DTOs.BatchIngredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.DTOs.Batch
{
    public class BatchCreateDto
    {
        public string BatchCode { get; set; }  
        public int Quantity { get; set; }  
        public DateTime ProductionDate { get; set; }  
        public decimal ExpectedSales { get; set; }  
        public decimal ExpectedProfitPercentage { get; set; }  
        public int ProductId { get; set; }  
        public ICollection<BatchIngredientCreateDto> BatchIngredientsCreateDto { get; set; }
    }
}
