using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Application.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
