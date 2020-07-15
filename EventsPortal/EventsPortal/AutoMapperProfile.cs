using AutoMapper;
using EventsPortal.ViewModel;
using Service.DTO;

namespace EventsPortal
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EventTypeViewModel, EventTypeDTO>();
            CreateMap<EventTypeDTO, EventTypeViewModel>();
        }
    }
}
