using MehmanFoods.Core.DTOs.OrderDetail;
using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        public Task AddOrderDetailAsync(OrderDetailDto orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderDetailAsync(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailDto> GetOrderDetailByIdAsync(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderDetailAsync(OrderDetailDto orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
