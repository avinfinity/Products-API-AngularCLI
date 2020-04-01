using Product.Common;
using Product.DAL;
using System.Threading.Tasks;

namespace Product.Services
{
    public interface IProductCommandsSvc
    {
        Task<bool> AddNewProductAsync(ProductDTO newProduct);

        Task<bool> RemoveProductAsync(int id);

        Task<bool> ModifyProductAsync(ProductDTO productModel);
    }
}