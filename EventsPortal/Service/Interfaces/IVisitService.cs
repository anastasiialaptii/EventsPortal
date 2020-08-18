using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IVisitService
    {
        IEnumerable<VisitDTO> GetVisits();

        IEnumerable<VisitDTO> GetVisitorsPerEvent(int id);

        IEnumerable<int> GetConfirmedVisits(int userId);

        Task AddVisit(VisitDTO visitDTO);
    }
}
