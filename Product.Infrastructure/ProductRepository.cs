using Microsoft.EntityFrameworkCore;
using Product.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    internal sealed class ProductRepository : IProductsRepository
    {
        private readonly ProductDBContext _productDBContext;

        public ProductRepository(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }

        public async Task<bool> AddNewProductAsync(ProductEntity entity)
        {
            var result = await _productDBContext.ProductModel.AddAsync(entity);
            return await Task.FromResult(result.State == EntityState.Added);
        }

        public Task<IQueryable<string>> GetAllCategories()
        {
           var categories = _productDBContext.ProductModel.Select(product => product.Category).Distinct();
            return Task.FromResult(categories);
        }

        public Task<IQueryable<ProductEntity>> GetAllProducts()
        {
            return Task.FromResult(_productDBContext.ProductModel.AsQueryable());
        }

        public async Task<ProductEntity> GetAsync(int id)
        {
            var entity = await _productDBContext.ProductModel.FindAsync(id);
            if (entity == null)
            {
                throw new ProductNotFoundException(id);
            }
            return await Task.FromResult(entity);
        }

        public Task<IQueryable<ProductEntity>> GetProductsForCategoryAsync(string category)
        {
            return Task.FromResult(_productDBContext.ProductModel.Where(entity => entity.Category == category));
        }

        public Task<bool> ModifyProductAsync(ProductEntity modified)
        {
            _productDBContext.Entry(modified).State = EntityState.Modified;
            return Task.FromResult(true);
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            var entity = await _productDBContext.ProductModel.FindAsync(id);
            if (entity == null)
            {
                throw new ProductNotFoundException(id);
            }

            var entry = _productDBContext.ProductModel.Remove(entity);
            return await Task.FromResult(entry.State == EntityState.Deleted);
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _productDBContext.SaveChangesAsync();
            return await Task.FromResult(result > 0);
        }
    }
}