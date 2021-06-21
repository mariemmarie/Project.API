using AutoMapper;
using Project.Core.Dto;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Consultant, AddConsultantDto>().ReverseMap();
            CreateMap<Consultant, GetConsultantDto>().ReverseMap();
            CreateMap<Consultant, PutConsultantDto>().ReverseMap()
               .ForMember(from => from.Id, opt => opt.Ignore());


            CreateMap<Consultant, PatchConsultantDto>().ReverseMap();
        }
    }
}
