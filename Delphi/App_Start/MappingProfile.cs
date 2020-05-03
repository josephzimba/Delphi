using AutoMapper;
using Delphi.Dtos;
using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delphi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Client, ClientDto>();
            Mapper.CreateMap<ClientDto, Client>();

            Mapper.CreateMap<StaffDto, Staff>();
            Mapper.CreateMap<Staff, StaffDto>();

        }
    }
}