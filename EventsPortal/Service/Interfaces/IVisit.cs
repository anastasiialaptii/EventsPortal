using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IVisit
    {
        Task<IEnumerable<VisitDTO>> GetVisits();

        Task<VisitDTO> GetVisitById();

        Task DeleteVisit(VisitDTO VisitDTO);

        Task EditVisit(VisitDTO VisitDTO);

        Task AddVisit(VisitDTO VisitDTO);
    }
}
