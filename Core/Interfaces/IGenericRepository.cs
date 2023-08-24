using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IReadOnlyList<T>> GetAllItemsAsync();
        public Task<T> GetItemsByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetItemsWithSpecAsync(ISpecification<T> spec);
        public Task<T> FindItemWithSpecAsync(int id, ISpecification<T> spec);
    }
}