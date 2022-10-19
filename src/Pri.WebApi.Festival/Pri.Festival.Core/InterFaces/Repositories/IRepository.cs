using Pri.Festivals.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> UpdateAsync(T entity);
        Task<bool> AddAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAll();
    }
}
