using Core.Entities;
using Repository;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Event> Events { get; }

        Task Save();
    }
}
