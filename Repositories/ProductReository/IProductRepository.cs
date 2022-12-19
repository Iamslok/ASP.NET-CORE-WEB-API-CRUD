using WEB_API.Models.DTO;

namespace WEB_API.Repositories.ProductReository
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
    }
}
