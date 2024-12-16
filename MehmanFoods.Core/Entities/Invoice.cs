using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }  // e.g., "2024-1"
        public DateTime CreatedAt { get; set; }  // Timestamp of the invoice creation
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
