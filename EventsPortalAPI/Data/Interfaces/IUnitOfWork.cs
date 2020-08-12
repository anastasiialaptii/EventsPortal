using Core.Entities;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Event> Events { get; }

        IRepository<Visit> Visits { get; }

        IRepository<User> Users { get; }

        Task SaveAsync();
    }
}
