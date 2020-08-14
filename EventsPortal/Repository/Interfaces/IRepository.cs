using System;
using System.Linq;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        void Delete(TEntity item);

        void Update(TEntity item);

        IQueryable<TEntity> GetItems();

        TEntity GetItem(int? id);

        TEntity FindItem(Func<TEntity, bool> item);
    }
}
