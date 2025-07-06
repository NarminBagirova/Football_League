using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
