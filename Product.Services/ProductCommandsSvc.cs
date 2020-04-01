using AutoMapper;
using Product.Common;
using Product.DAL;
using Product.Domain;
using System.Threading.Tasks;

namespace Product.Services
{
    internal sealed class ProductCommandsSvc : IProductCommandsSvc
    {
        private readonly IProductAggregateRoot _products;
        private readonly IMapper _mapper;

        public ProductCommandsSvc(IProductAggregateRoot productAggregateRoot, IMapper mapper)
        {
            _products = productAggregateRoot;
            _mapper = mapper;
        }

        public async Task<bool> AddNewProductAsync(ProductDTO productDTO)
        {
            return await _products.AddNewProductAsync(_mapper.Map<ProductEntity>(productDTO));
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            return await _products.RemoveProductAsync(id);
        }

        public async Task<bool> ModifyProductAsync(ProductDTO productDTO)
        {
            return await _products.ModifyProductAsync(_mapper.Map<ProductEntity>(productDTO));
        }
    }
}