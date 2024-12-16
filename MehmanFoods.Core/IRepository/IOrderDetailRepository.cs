using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IRepository
{
    public interface IOrderDetailRepository
    {
        Task AddOrderDetailAsync(OrderDetail orderDetail);
        Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId);
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int orderDetailId);
    }
}
