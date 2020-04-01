using Product.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public interface IProductsRepository
    {
        Task<IQueryable<ProductEntity>> GetAllProducts();

        Task<IQueryable<string>> GetAllCategories();

        Task<IQueryable<ProductEntity>> GetProductsForCategoryAsync(string category);

        Task<bool> AddNewProductAsync(ProductEntity entity);

        Task<bool> ModifyProductAsync(ProductEntity modified);

        Task<bool> RemoveProductAsync(int id);

        Task<ProductEntity> GetAsync(int id);

        Task<bool> SaveAsync();
    }
}