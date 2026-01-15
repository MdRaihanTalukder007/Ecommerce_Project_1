using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Categories = new BaseRepository<Category>(_db);
            Products = new BaseRepository<Product>(_db);
        }

        public IBaseRepository<Category> Categories { get; }
        public IBaseRepository<Product> Products { get; }

        public Task<int> SaveChangesAsync() => _db.SaveChangesAsync();
    }
}
