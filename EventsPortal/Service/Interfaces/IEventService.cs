using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEventService
    {
        IEnumerable<EventDTO> GetEvents();

        IEnumerable<EventDTO> GetPublicEvents();

        IEnumerable<EventDTO> GetPublicOwnEvents(string userId);

        IEnumerable<EventDTO> SearchEvents(string userId, string eventName);

        EventDTO GetEvent(int? id);

        Task DeleteEvent(int? id);

        Task EditEvent(EventDTO eventDTO);

        Task AddEvent(EventDTO eventDTO);

        //  Task<List<int>> IsEventUserCreated(string userId);

    }
}
