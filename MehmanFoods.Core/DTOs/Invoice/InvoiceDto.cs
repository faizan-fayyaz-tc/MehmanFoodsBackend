using MehmanFoods.Core.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.DTOs.Invoice
{
    public class InvoiceDto
    {
        public string InvoiceNo { get; set; }  
        public DateTime CreatedAt { get; set; }
        public OrderCreateDto orderCreateDto { get; set; }
    }
}
