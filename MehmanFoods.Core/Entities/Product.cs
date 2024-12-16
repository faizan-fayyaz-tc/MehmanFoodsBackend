using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductWholeSalePrice { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Symbol { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Batch> Batches { get; set; }
        public ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
