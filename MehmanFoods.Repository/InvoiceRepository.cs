using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly MehmanFoodsDbContext _context;

        public InvoiceRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task CreateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<Invoice> GetLastInvoiceNumberAsync()
        {
            return await _context.Invoices.OrderByDescending(i=>i.InvoiceId).FirstOrDefaultAsync();
        }
    }
}
