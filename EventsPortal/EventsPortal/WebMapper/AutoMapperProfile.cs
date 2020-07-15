using AutoMapper;
using EventsPortal.ViewModel;
using Service.DTO;

namespace EventsPortal.WebMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EventViewModel, EventDTO>();
            CreateMap<EventDTO, EventViewModel>();
        }
    }
}
