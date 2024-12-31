using MehmanFoods.Core.DTOs.Customer;
using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace MehmanFoods.Endpoints.MehmanFoodsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            if (customerCreateDto != null)
            {
                await _customerService.AddCustomerAsync(customerCreateDto);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customerCreateDto.CustomerId }, customerCreateDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerFetchDto>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound("customer not found");
            }
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<CustomerFetchDto>> GetAllCustomersAsync()
        {
            var customer = await _customerService.GetAllCustomersAsync();
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound("customer not found");
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<ActionResult<CustomerUpdateDto>> UpdateCustomerById([FromBody] CustomerUpdateDto customerUpdateDto)
        {
            await _customerService.UpdateCustomerAsync(customerUpdateDto);
            return Ok(new { success = true, message = "Customer Updated Successfully" });
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomerById(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok(new { success = true, message = "Customer Deleted Successfully" });
        }
    }
}
