using MehmanFoods.Core.DTOs.Order;
using MehmanFoods.Core.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.DTOs.OrderDetail
{
    public class OrderDetailFetchDto
    {
        public int OrderDetailId { get; set; }
       // public int ProductId { get; set; }
        public ProductFetchDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
