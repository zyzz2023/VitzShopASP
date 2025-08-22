using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Common;
using VitzShop.Domain.Repository;

namespace VitzShop.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity<Guid>, IAggregateRoot
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>?> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(Guid id);
        void Update(T entity);  
    }
}