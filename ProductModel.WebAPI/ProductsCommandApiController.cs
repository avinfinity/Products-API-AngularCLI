using Microsoft.AspNetCore.Mvc;
using Product.Common;
using Product.Infrastructure;
using Product.Services;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace ProductModel.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsCommandApiController : ControllerBase
    {
        private readonly IProductCommandsSvc _productCommandSvc;

        public ProductsCommandApiController(IProductCommandsSvc productCommandsSvc)
        {
            _productCommandSvc = productCommandsSvc;
        }

        [HttpPut]
        public async Task<IActionResult> ModifyProductAsync([NotNull][FromBody]ProductDTO productDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productCommandSvc.ModifyProductAsync(productDTO);
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductAsync([NotNull][FromBody]ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productCommandSvc.AddNewProductAsync(productDTO);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _productCommandSvc.RemoveProductAsync(id);
            }
            catch (ProductNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            
            return Ok(true);
        }
    }
}