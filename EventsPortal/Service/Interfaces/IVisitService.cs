using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IVisitService
    {
        Task<IEnumerable<VisitDTO>> GetVisits();

        Task AddVisit(VisitDTO visitDTO);

        Task<IEnumerable<VisitDTO>> GetVisitorsByEvent(int eventId);
    }
}
