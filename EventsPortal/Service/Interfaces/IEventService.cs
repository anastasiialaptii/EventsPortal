using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEvents();
    }
}
