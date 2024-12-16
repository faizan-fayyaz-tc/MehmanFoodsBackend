using MehmanFoods.Core.DTOs.Invoice;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> GetLastInvoiceNumberAsync();
        Task CreateInvoiceAsync(InvoiceDto invoice);
    }
}
