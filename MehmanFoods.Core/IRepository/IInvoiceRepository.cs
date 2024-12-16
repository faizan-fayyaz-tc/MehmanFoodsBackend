using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetLastInvoiceNumberAsync();
        Task CreateInvoiceAsync(Invoice invoice);
    }
}
