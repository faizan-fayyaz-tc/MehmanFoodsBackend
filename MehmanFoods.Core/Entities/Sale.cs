using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class Sale
    {
        public int SaleId { get; set; } 
        public int OrderId { get; set; } 
        public int InvoiceNo { get; set; } 
        public decimal TotalAmount { get; set; } 
        public DateTime SaleDate { get; set; } 
        public string PaymentStatus { get; set; } 
        public Order Order { get; set; }
        public ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
