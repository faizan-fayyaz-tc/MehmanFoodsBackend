using MehmanFoods.Core.DTOs.Batch;
using MehmanFoods.Core.DTOs.Customer;
using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.IRepository;
using MehmanFoods.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace MehmanFoods.Endpoints.MehmanFoodsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpPost("CreateBatch")]
        public async Task<ActionResult> CreateBatch([FromBody] BatchCreateDto batchCreateDto)
        {
            if (batchCreateDto != null)
            {
                await _batchService.AddBatchAsync(batchCreateDto);
                return CreatedAtAction(nameof(GetBatchById), new { id = batchCreateDto.BatchCode }, batchCreateDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchCreateDto>> GetBatchById(int id)
        {
            var customer = await _batchService.GetBatchByIdAsync(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound("customer not found");
            }
        }
    }
}
