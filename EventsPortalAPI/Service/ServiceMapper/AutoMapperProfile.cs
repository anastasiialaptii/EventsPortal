﻿using AutoMapper;
using Core.DTO;
using Core.Entities;

namespace Service.ServiceMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();

            CreateMap<Visit, VisitDTO>();
            CreateMap<VisitDTO, Visit>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<EventType, EventTypeDTO>();
            CreateMap<EventTypeDTO, EventType>();
        }
    }
}
