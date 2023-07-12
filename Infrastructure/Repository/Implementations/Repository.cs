using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository : IRepository
    {
    private StoreContext _dbContext;
        public Repository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}