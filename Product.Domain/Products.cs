using Product.DAL;
using Product.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Domain
{
    internal sealed class Products : IProductAggregateRoot
    {
        private readonly IProductsRepository _productsRepository;

        public Products(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<bool> AddNewProductAsync([NotNull] ProductEntity product)
        {
            await _productsRepository.AddNewProductAsync(product);
            return await _productsRepository.SaveAsync();
        }

        public async Task<IQueryable<ProductEntity>> GetAllProducts()
        {
            return  await _productsRepository.GetAllProducts();
        }

        public Task<IQueryable<string>> GetAllCategories()
        {
            return _productsRepository.GetAllCategories();
        }

        public async Task<IQueryable<ProductEntity>> GetProductForCategory([NotNull]string category)
        {
            return await _productsRepository.GetProductsForCategoryAsync(category);
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            await _productsRepository.RemoveProductAsync(id);
            return await _productsRepository.SaveAsync();
        }

        public async Task<ProductEntity> GetProductAsync(int id)
        {
            return await _productsRepository.GetAsync(id);
        }

        public async Task<bool> ModifyProductAsync(ProductEntity modified)
        {
            await _productsRepository.ModifyProductAsync(modified);
            return await _productsRepository.SaveAsync();
        }
    }
}