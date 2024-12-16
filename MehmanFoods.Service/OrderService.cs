using AutoMapper;
using MehmanFoods.Core.DTOs.Invoice;
using MehmanFoods.Core.DTOs.Order;
using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using MehmanFoods.Core.IService;
using MehmanFoods.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
       // private readonly IInvoiceService _invoiceService;
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IInvoiceService invoiceService, IMapper mapper, IOrderDetailRepository orderDetailRepository, IInvoiceRepository invoiceRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
           // _invoiceService = invoiceService;
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        public async Task AddOrderAsync(OrderCreateDto orderCreateDto)
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month.ToString("D2");
            var lastInvoice = await _invoiceRepository.GetLastInvoiceNumberAsync();

            var newInvoiceNumber = lastInvoice == null || lastInvoice.InvoiceNo.Split('-')[1] != currentMonth
                ? $"{currentYear}-{currentMonth}-1"
                : $"{currentYear}-{currentMonth}-{int.Parse(lastInvoice.InvoiceNo.Split('-')[2]) + 1}";

           // var order = _mapper.Map<Order>(orderCreateDto);

           // order.InvoiceNo = newInvoiceNumber;

           // var newOrder = await _orderRepository.AddOrderAsync(order);

            decimal subTotalCost = 0;

            using (var transaction = await _orderRepository.BeginTransactionAsync())
            {
                try
                {
                    var order = _mapper.Map<Order>(orderCreateDto);
                    order.InvoiceNo = newInvoiceNumber;
                    order.CustomerId = orderCreateDto.CustomerId;

                    var newOrder = await _orderRepository.AddOrderAsync(order);

                    foreach (var orderDetailDto in orderCreateDto.OrderDetailsDto)
                    {
                        var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
                        orderDetail.OrderId = newOrder.OrderId;

                        var orderProduct = await _productRepository.GetProductByIdAsync(orderDetail.ProductId);
                        if (orderProduct.ProductQuantity == 0)
                        {
                            throw new Exception($"Product {orderProduct.ProductName} is out of stock.");
                        }
                        if (orderProduct.ProductQuantity < orderDetail.Quantity)
                        {
                            throw new Exception($"Insufficient quantity for product {orderProduct.ProductName}. Available: {orderProduct.ProductQuantity}, Requested: {orderDetailDto.Quantity}.");
                        }

                        orderDetail.TotalPrice = orderDetail.Quantity * orderDetail.Price;
                        subTotalCost += orderDetail.TotalPrice;

                        await _orderDetailRepository.AddOrderDetailAsync(orderDetail);

                        orderProduct.ProductQuantity -= orderDetail.Quantity;
                        await _productRepository.UpdateProductAsync(orderProduct);
                    }

                    newOrder.SubTotalCost = subTotalCost;
                    newOrder.Balance = subTotalCost - newOrder.PaidAmount;
                    await _orderRepository.UpdateOrderAsync(newOrder);

                    var invoice = new Invoice
                    {
                        InvoiceNo = newInvoiceNumber,
                        CreatedAt = DateTime.Now,
                        OrderId = newOrder.OrderId
                    };
                    await _invoiceRepository.CreateInvoiceAsync(invoice);

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public Task DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public Task UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
