using MehmanFoods.Core.DTOs.OrderDetail;
using MehmanFoods.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Core.IService
{
    public interface IOrderDetailService
    {
        Task AddOrderDetailAsync(OrderDetailDto orderDetail);
        Task<OrderDetailDto> GetOrderDetailByIdAsync(int orderDetailId);
        Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync();
        Task UpdateOrderDetailAsync(OrderDetailDto orderDetail);
        Task DeleteOrderDetailAsync(int orderDetailId);
    }
}
