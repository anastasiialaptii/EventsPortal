using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEvents();

        Task<IEnumerable<EventDTO>> GetEventById(int? id);

        Task DeleteEvent(int? id);

        Task EditEvent(EventDTO eventDTO);

        Task AddEvent(EventDTO eventDTO);

        Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId, string searchEvent);

        Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent);

    }
}
