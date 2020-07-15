using AutoMapper;
using Core.Entities;
using Service.DTO;

namespace Service.ServiceMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
        }
    }
}
