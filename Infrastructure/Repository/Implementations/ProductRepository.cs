//using Infrastructure.Data;
//using Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using Core.Interfaces;

//namespace Infrastructure.Repository
//{
//    public class ProductRepository : IProductRepository
//    {
//    private readonly StoreContext _dbContext;
//        public ProductRepository(StoreContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
        
//        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
//        {
//             return await _dbContext.Products
//             .Include(p => p.ProductBrand)
//             .Include(p => p.ProductType)
//             .ToListAsync();
//        }

//        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync()
//        {
//            return await _dbContext.ProductBrands.ToListAsync();
//        }

//        public async Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync()
//        {
//            return await _dbContext.ProductTypes.ToListAsync();
//        }

//        public async Task<Product> GetProductByIdAsync(int id)
//        {
//            return await _dbContext.Products
//            .Include(p => p.ProductBrand)
//            .Include
//            .FindAsync(id);
//        }
//    }
//}