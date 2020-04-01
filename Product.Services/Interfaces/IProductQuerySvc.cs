using Product.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Services
{
    public interface IProductQuerySvc
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        Task<IQueryable<string>> GetAllCategories();

        Task<IEnumerable<ProductDTO>> GetProductForCategoryAsync(string productCategory);

        Task<ProductDTO> GetProductAsync(int id);
    }
}