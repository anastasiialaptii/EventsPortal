using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        void Delete(TEntity item);

        void Update(TEntity item);

        IQueryable<TEntity> GetItems();

        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetItem(int? id);

        TEntity FindItem(Func<TEntity, bool> item);
    }
}
