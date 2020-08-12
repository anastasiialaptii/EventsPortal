using AutoMapper;
using Core.DTO;
using Core.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VisitService : IVisitService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;

        public VisitService(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public async Task AddVisit(VisitDTO visitDTO)
        {
            _dbOperation.Visits.Create(
                _mapper.Map<Visit>(visitDTO));
            await _dbOperation.SaveAsync();
        }

        public async Task<int> GetTotalVisitorsPerEvent(int eventId)
        {
            var events = _mapper.Map<List<VisitDTO>>(
            await _dbOperation.Visits.GetAllAsync());

            var visitorsPerEvent = new List<VisitDTO>();

            foreach (var item in events)
            {
                if (item.EventId == eventId)
                    visitorsPerEvent.Add(item);
            }
            return visitorsPerEvent.Count;
        }

        public async Task<IEnumerable<VisitDTO>> GetVisitorsByEvent(int eventId)
        {
            var eventVisitorsList = _mapper.Map<List<VisitDTO>>(
                await _dbOperation.Visits.GetAllAsync());

            var visitorsList = new List<VisitDTO>();
            foreach (var item in eventVisitorsList)
            {
                if (item.EventId == eventId)
                {
                    visitorsList.Add(item);
                }
            }
            return visitorsList;
        }

        public async Task<IEnumerable<VisitDTO>> GetVisits()
        {
            return _mapper.Map<List<VisitDTO>>(
                await _dbOperation.Visits.GetAllAsync());
        }
    }
}
