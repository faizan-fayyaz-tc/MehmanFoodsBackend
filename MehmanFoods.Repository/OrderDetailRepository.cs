using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
         private readonly MehmanFoodsDbContext _context;

        public OrderDetailRepository(MehmanFoodsDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public Task DeleteOrderDetailAsync(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
