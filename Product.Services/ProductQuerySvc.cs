using AutoMapper;
using Product.Common;
using Product.DAL;
using Product.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Services
{
    internal class ProductQuerySvc : IProductQuerySvc
    {
        private readonly IProductAggregateRoot _products;
        private readonly IMapper _mapper;

        public ProductQuerySvc(IProductAggregateRoot  productAggregateRoot, IMapper mapper)
        {
            _products = productAggregateRoot;
            _mapper = mapper;
        }

        public Task<IQueryable<string>> GetAllCategories()
        {
            return _products.GetAllCategories();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var results = await _products.GetAllProducts();
            return await Task.FromResult(_mapper.Map<IQueryable<ProductEntity>, IEnumerable<ProductDTO>>(results));
        }

        public async Task<ProductDTO> GetProductAsync(int id)
        {
            var product = await _products.GetProductAsync(id);
            return await Task.FromResult(_mapper.Map<ProductDTO>(product));
        }

        public async Task<IEnumerable<ProductDTO>> GetProductForCategoryAsync(string productCategory)
        {
            var products =  await _products.GetProductForCategory(productCategory);
            return await Task.FromResult(_mapper.Map<IQueryable<ProductEntity>, IEnumerable<ProductDTO>>(products));
        }
    }
}