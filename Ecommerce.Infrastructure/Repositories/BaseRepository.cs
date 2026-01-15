using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _set;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _set.AsNoTracking();
            if (filter is not null) query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
            => await _set.FindAsync(id);

        public async Task AddAsync(T entity)
            => await _set.AddAsync(entity);

        public void Update(T entity)
        {
            entity.UpdatedAtUtc = DateTime.UtcNow;
            _set.Update(entity);
        }

        public void Remove(T entity)
            => _set.Remove(entity);
    }
}
