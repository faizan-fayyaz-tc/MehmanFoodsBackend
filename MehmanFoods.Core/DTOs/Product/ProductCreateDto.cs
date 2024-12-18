using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.DTOs.Product
{
    public class ProductCreateDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; } // opening stock quantity
        public decimal ProductPrice { get; set; } // sale rate b2c 
        public decimal ProductWholeSalePrice { get; set; } // sale rate 2  b2b
        public decimal ProductBuyRatePrice { get; set; }
        public decimal OpeningStockRate { get; set; }
        public int MinimumStockAlert { get; set; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; } 
        public DateTime ExpiryDate { get; set; } 
        public string Symbol { get; set; }

        // description
        // buy rate/ cost making for this product
    }

    
}
