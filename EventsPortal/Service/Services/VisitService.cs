using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
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

        public async Task<IEnumerable<VisitDTO>> GetVisits()
        {
            return _mapper.Map<List<VisitDTO>>(
                await _dbOperation.Visits.GetAllAsync());
        }
    }
}
