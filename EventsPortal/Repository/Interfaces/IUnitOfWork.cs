using Core.Entities;
using Repository;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<EventType> EventTypes { get; }

        Task Save();
    }
}
