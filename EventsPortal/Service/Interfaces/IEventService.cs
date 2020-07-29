using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEvents();

        Task<EventDTO> GetEventById(int? id);

        Task DeleteEvent(int? id);

        Task EditEvent(EventDTO eventDTO);

        Task AddEvent(EventDTO eventDTO);

        Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId);

        Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent);

    }
}
