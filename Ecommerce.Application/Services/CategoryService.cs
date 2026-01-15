using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow) => _uow = uow;

        public Task<List<Category>> GetAllAsync() => _uow.Categories.GetAllAsync();

        public Task<Category?> GetByIdAsync(int id) => _uow.Categories.GetByIdAsync(id);

        public async Task CreateAsync(Category category)
        {
            await _uow.Categories.AddAsync(category);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _uow.Categories.Update(category);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _uow.Categories.GetByIdAsync(id);
            if (entity is null) return; 
            _uow.Categories.Remove(entity);
            await _uow.SaveChangesAsync();
        }
    }
}
