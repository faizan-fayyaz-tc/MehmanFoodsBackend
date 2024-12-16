using MehmanFoods.Core.DTOs.Invoice;
using MehmanFoods.Core.DTOs.OrderDetail;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.DTOs.Order
{
    public class OrderCreateDto
    {
       // public InvoiceDto Invoice { get; set; }
        public string InvoiceTo { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        //public decimal SubTotalCost { get; set; }
        public decimal PaidAmount { get; set; }
        //public decimal Balance { get; set; }
        public string PaymentStatus { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderDetailDto> OrderDetailsDto { get; set; }
    }
}
