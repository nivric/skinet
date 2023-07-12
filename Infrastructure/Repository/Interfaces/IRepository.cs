using Core.Entities;

namespace Infrastructure.Repository
{
    public interface IRepository
    {
        public Task<List<Product>> GetAllProducts();
    }
}