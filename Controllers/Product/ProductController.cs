using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.DTO;
using WEB_API.Repositories.ProductReository;

namespace WEB_API.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            try
            {
                var res = await _productRepository.GetAllProducts();
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetProductById/{productid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ProductDTO> GetProductById(int productId)
        {
            try
            {
                var res = await _productRepository.GetProductById(productId);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
