using Repository;
using Service.DTO;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<EventDTO> Events { get; }

        //IRepository<VisitDTO> Visits { get; }

        IRepository<UserDTO> Users { get; }

        Task Save();
    }
}
