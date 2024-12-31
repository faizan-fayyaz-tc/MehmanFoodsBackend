using MehmanFoods.Core.DTOs.Order;
using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.IService;
using MehmanFoods.Service;
using Microsoft.AspNetCore.Mvc;

namespace MehmanFoods.Endpoints.MehmanFoodsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto != null)
            {
                await _orderService.AddOrderAsync(orderCreateDto);
                return CreatedAtAction(nameof(GetOrderById), new { id = orderCreateDto.OrderId }, orderCreateDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<ActionResult<ProductCreateDto>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound("order not found");
            }
        }

        [HttpGet("Fetch-Orders")]
        public async Task<ActionResult<OrderFetchDto>> GetAllOrdersAsync(int id)
        {
            var orders = await _orderService.GetAllOrdersAsync();
            if (orders != null)
            {
                return Ok(orders);
            }
            else
            {
                return NotFound("No Order Exist!.");
            }
        }
    }
}
