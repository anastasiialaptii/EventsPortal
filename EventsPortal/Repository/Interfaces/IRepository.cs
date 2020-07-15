using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        //void Create(T item);

        //void Delete(T item);

        //void Update(T item);

        IEnumerable<T> GetAllAsync();

        //Task<T> FindItemAsync(Func<T, bool> item);

        //Task<T> GetIdAsync(int? id);
    }
}
