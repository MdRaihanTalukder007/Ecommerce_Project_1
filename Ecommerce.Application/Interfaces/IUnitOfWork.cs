using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Product> Products { get; }
        Task<int> SaveChangesAsync();
    }
}
