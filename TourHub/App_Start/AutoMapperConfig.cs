using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourHub.DTOs;
using TourHub.Models;

namespace TourHub.App_Start
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //way two
                cfg.AddProfile<MappingProfile>();
            }
           );

            return config;
        }
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<ApplicationUser, UserDTO>();
                CreateMap<Tour, TourDTO>();
                CreateMap<Notification, NotificationDTO>();
            }
        }
    }
}