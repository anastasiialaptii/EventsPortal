using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);

        void Delete(T item);

        void Update(T item);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetIdAsync(int? id);
    }
}
