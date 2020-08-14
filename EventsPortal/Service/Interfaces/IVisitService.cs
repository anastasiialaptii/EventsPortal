using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IVisitService
    {
        IEnumerable<VisitDTO> GetVisits();

        Task AddVisit(VisitDTO visitDTO);
    }
}
