using AutoMapper;
using HairdressingStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullCollections = null;
            CreateMap<Stylists, StylistsDTO>();
            CreateMap<HairdressingServices, HairdressingServicesDTO>();
            CreateMap<StylistsWorkingHours, StylistsWorkingHoursDTO>();
            CreateMap<Clients, ClientsDTO>().ReverseMap();
        }
    }
}
