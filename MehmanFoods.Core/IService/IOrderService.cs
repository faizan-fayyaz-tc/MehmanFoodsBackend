using MehmanFoods.Core.DTOs.Order;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IOrderService
    {
        Task AddOrderAsync(OrderCreateDto orderCreateDto);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
    }
}
