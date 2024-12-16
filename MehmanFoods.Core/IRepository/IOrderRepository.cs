using MehmanFoods.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
