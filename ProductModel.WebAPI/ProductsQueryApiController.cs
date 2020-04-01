using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Common;
using Product.Infrastructure;
using Product.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductModel.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsQueryApiController : ControllerBase
    {
        private readonly IProductQuerySvc _productQuerySvc;

        public ProductsQueryApiController(IProductQuerySvc productQuerySvc)
        {
            _productQuerySvc = productQuerySvc;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
           return await _productQuerySvc.GetAllProductsAsync();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            try
            {
                return await _productQuerySvc.GetProductAsync(id);
            }
            catch (ProductNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IEnumerable<string>> GetCategories()
        {
            return await _productQuerySvc.GetAllCategories();
        }

        [HttpGet("cat={category}")]
        public async Task<IEnumerable<ProductDTO>> GetProductForCategory(string category)
        {
            return await _productQuerySvc.GetProductForCategoryAsync(category);
        }
    }
}