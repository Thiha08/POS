using POS.Core.Aggregates;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure.Data
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        Task<T> GetByIdAsync(long id);

        IQueryable<T> GetAll();

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
