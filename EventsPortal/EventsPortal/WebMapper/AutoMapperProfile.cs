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

            CreateMap<VisitViewModel, VisitDTO>();
            CreateMap<VisitDTO, VisitViewModel>();

            CreateMap<UserViewModel, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();

            CreateMap<UserRoleViewModel, UserRoleDTO>();
            CreateMap<UserRoleDTO, UserRoleViewModel>();

            CreateMap<EventTypeViewModel, EventTypeDTO>();
            CreateMap<EventTypeDTO, EventTypeViewModel>();
        }
    }
}
