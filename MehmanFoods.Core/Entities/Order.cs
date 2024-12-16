using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
       // public Invoice Invoice { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceTo { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal SubTotalCost { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Balance { get; set; }
        public string PaymentStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
