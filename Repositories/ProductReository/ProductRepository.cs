using Microsoft.EntityFrameworkCore;
using WEB_API.Data;
using WEB_API.Models.DTO;

namespace WEB_API.Repositories.ProductReository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ProductRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }   

        //To Get ALL the Products
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            //This qurey is about to get all product that should be IsActive=true and IsDelete=false
            var res = await _dbcontext.Products.Where(x => x.IsActive && !x.IsDelete).AsNoTracking().Select(x => new ProductDTO
            {
                ProductId = x.Id,
                ProductName = x.Productname,
                Price = x.Price,
            }).ToListAsync();

            return res;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
                var res = await _dbcontext.Products.Where(x => x.Id == id).AsNoTracking().Select(x => new ProductDTO
                {
                    ProductId = x.Id,
                    ProductName = x.Productname,
                    Price = x.Price
                }).FirstOrDefaultAsync();

                return res;
        }
    }
}
