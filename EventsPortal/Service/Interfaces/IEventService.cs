using Service.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEventService
    {
        IEnumerable<EventDTO> GetEvents();

        IEnumerable<EventDTO> GetPublicEvents();

        IEnumerable<EventDTO> GetPublicOwnEvents(string userId);

        EventDTO GetEvent(int? id);

        Task DeleteEvent(int? id);

        Task EditEvent(EventDTO eventDTO);

        Task AddEvent(EventDTO eventDTO);

        //Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId, string searchEvent);

        //Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent);

        //Task<List<int>> IsEventUserCreated(string userId);

    }
}
