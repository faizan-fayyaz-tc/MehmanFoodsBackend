using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MehmanFoodsDbContext _context;

        public OrderRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            var newOrder =  _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return newOrder.Entity;
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
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            return order;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
