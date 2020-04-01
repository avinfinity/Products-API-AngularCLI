using Product.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Domain
{
    public interface IProductAggregateRoot
    {
        Task<IQueryable<ProductEntity>> GetAllProducts();

        Task<IQueryable<string>> GetAllCategories();

        Task<IQueryable<ProductEntity>> GetProductForCategory(string category);

        Task<ProductEntity> GetProductAsync(int id);

        Task<bool> AddNewProductAsync(ProductEntity productDTO);

        Task<bool> RemoveProductAsync(int id);

        Task<bool> ModifyProductAsync(ProductEntity modifiedDTO);
    }
}