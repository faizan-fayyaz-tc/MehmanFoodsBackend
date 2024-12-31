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
        private readonly ICustomerRepository _customerRepository;
        private readonly IPaymentStatusService _paymentStatusService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IInvoiceService invoiceService, IMapper mapper, IOrderDetailRepository orderDetailRepository, IInvoiceRepository invoiceRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IPaymentStatusService paymentStatusService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
           // _invoiceService = invoiceService;
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
            _paymentStatusService = paymentStatusService;
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

                    var customer = await _customerRepository.GetCustomerByIdAsync(orderCreateDto.CustomerId);

                    if (customer != null)
                    {
                        order.PhoneNumber = customer.PhoneNumber;  
                        order.InvoiceTo = customer.FullName;      
                        order.Location = customer.Address;            
                    }
                    else
                    {
                        throw new Exception("Customer not found");
                    }

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

                        if(orderDetailDto.SelectedPriceType == "WholeSalePrice")
                        {
                            orderDetail.Price = orderProduct.ProductWholeSalePrice;
                        }
                        else
                        {
                            orderDetail.Price = orderProduct.ProductPrice;
                        }

                        orderDetail.TotalPrice = orderDetail.Quantity * orderDetail.Price;
                        subTotalCost += orderDetail.TotalPrice;

                        await _orderDetailRepository.AddOrderDetailAsync(orderDetail);

                        orderProduct.ProductQuantity -= orderDetail.Quantity;
                        await _productRepository.UpdateProductAsync(orderProduct);
                    }

                    newOrder.SubTotalCost = subTotalCost;
                    newOrder.Balance = subTotalCost - newOrder.PaidAmount;

                    if (newOrder == null)
                    {
                        throw new Exception("Order is not initialized.");
                    }

                    if (newOrder.PaidAmount == null || newOrder.SubTotalCost == null)
                    {
                        throw new Exception("Order PaidAmount or SubTotalCost is not set.");
                    }

                    var paymentStatus = await _paymentStatusService.GetPaymentStatusAsync(newOrder.PaidAmount, newOrder.SubTotalCost);

                    if (paymentStatus == null)
                    {
                        throw new Exception("Payment status could not be determined.");
                    }

                    newOrder.PaymentStatus = paymentStatus.Status;

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

        public async Task<IEnumerable<OrderFetchDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<IEnumerable<OrderFetchDto>>(orders);
        }

        public async Task<OrderFetchDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return _mapper.Map<OrderFetchDto>(order);
        }

        public Task UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
