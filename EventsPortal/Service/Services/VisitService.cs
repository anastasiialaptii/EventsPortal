using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<VisitDTO> GetVisitorsPerEvent(int id)
        {
            return _dbOperation.Visits.GetItems()
                .Where(x => x.EventId == id)
                .Select(x => new VisitDTO
                {
                    User = new UserDTO
                    {
                        Email = x.User.Email,
                        Name = x.User.Name
                    }
                }).ToList();
        }

        public IEnumerable<VisitDTO> GetVisits()
        {
            return _mapper.Map<List<VisitDTO>>(
                _dbOperation.Visits.GetItems()
                .Select(x => new VisitDTO
                {
                    EventId = x.EventId,
                    UserId = x.UserId
                }).ToList());
        }
    }
}
