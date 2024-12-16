using AutoMapper;
using MehmanFoods.Core.DTOs.Invoice;
using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task CreateInvoiceAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            await _invoiceRepository.CreateInvoiceAsync(invoice); 
        }

        public async Task<InvoiceDto> GetLastInvoiceNumberAsync()
        {
            var invoice = await _invoiceRepository.GetLastInvoiceNumberAsync();
            return _mapper.Map<InvoiceDto>(invoice);
        }
    }
}
