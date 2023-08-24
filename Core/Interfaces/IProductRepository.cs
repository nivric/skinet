using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        public Task<IReadOnlyList<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();
        public Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
    }
}