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
                Description = x.Description,
                Price = x.Price,
                IsActive = x.IsActive,
                IsDelete = x.IsDelete,
            }).ToListAsync();

            return res;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var res = await _dbcontext.Products.Where(x => x.Id == id).AsNoTracking().Select(x => new ProductDTO
            {
                ProductId = x.Id,
                ProductName = x.Productname,
                Description = x.Description,
                Price = x.Price,
                IsActive = x.IsActive,
                IsDelete = x.IsDelete,
            }).FirstOrDefaultAsync();

            return res;
        }

        public async Task UpdateProductById(UpdateProductDTO updateProduct)
        {
            if (updateProduct != null)
            {
                var res = await _dbcontext.Products.FirstOrDefaultAsync(x => x.Id == updateProduct.ProductId);
                if (res != null)
                {
                    res.Productname = updateProduct.ProductName;
                    res.Description = updateProduct.Description;
                    res.Price = updateProduct.Price;
                    res.IsActive = updateProduct.IsActive;
                    res.IsDelete = updateProduct.IsDelete;
                }
                else
                {
                    await _dbcontext.Products.AddAsync(new Models.product
                    {
                        Productname = updateProduct.ProductName,
                        Price = updateProduct.Price,
                        Description = updateProduct.Description,    
                        IsActive = updateProduct.IsActive,
                        IsDelete = updateProduct.IsDelete
                    });
                }
            }

            await _dbcontext.SaveChangesAsync();
        }
    }
}
