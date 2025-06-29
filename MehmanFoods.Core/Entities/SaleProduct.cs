﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class SaleProduct
    {
        public int SaleProductId { get; set; }  
        public int SaleId { get; set; }  
        public int ProductId { get; set; }  
        public int Quantity { get; set; }  
        public decimal UnitPrice { get; set; }  
        public Sale Sale { get; set; }  
        public Product Product { get; set; }  
    }
}
