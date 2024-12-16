using MehmanFoods.Core.DTOs.Product;
using MehmanFoods.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace MehmanFoods.Endpoints.MehmanFoodsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            if (productCreateDto != null)
            {
                await _productService.AddProductAsync(productCreateDto);
                return CreatedAtAction(nameof(GetProductById), new { id = productCreateDto.ProductId }, productCreateDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCreateDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound("product not found");
            }
        }

        [HttpPut("Update-Journal{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok();
        }
    }
}
