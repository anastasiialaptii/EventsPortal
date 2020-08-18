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

        //public IEnumerable<VisitDTO> GetEnrollEvents(int userId)
        //{
        //    //return _dbOperation.Events.GetItems()
        //    //    .Select(x => new VisitDTO { EventId = x.Id })
        //    //    .Where(y =>!_dbOperation.Visits.GetItems()
        //    //    .Select(x => x.EventId) .Contains(y.EventId))
        //    //    .ToList();
        //    _dbOperation.Events
        //        .GetItems()
        //        .Where(e=> e.Visits.Where(v => v.UserId == userId))
        //}

        public IEnumerable<int> GetConfirmedVisits(int userId)
        {
            return _dbOperation.Visits.GetItems()
                .Where(x => x.UserId == userId)
                .Select(x => x.EventId).ToList();
        }

        public IEnumerable<VisitDTO> GetVisitorsPerEvent(int id)
        {
            return _dbOperation.Visits.GetItems()
                .Where(x => x.EventId == id)
                .Select(x => new VisitDTO
                {
                    UserId = x.UserId,
                    EventId = x.EventId,
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
