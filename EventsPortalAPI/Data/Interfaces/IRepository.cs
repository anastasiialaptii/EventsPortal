using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        void Delete(TEntity item);

        void Update(TEntity item);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetIdAsync(int? id);

        TEntity FindItem(Func<TEntity, bool> item);
    }
}
