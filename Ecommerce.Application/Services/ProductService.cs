using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow) => _uow = uow;

        public Task<List<Product>> GetAllAsync() => _uow.Products.GetAllAsync();

        public Task<Product?> GetByIdAsync(int id) => _uow.Products.GetByIdAsync(id);

        public async Task CreateAsync(Product product)
        {
            await _uow.Products.AddAsync(product);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _uow.Products.Update(product);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _uow.Products.GetByIdAsync(id);
            if (entity is null) return;
            _uow.Products.Remove(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
