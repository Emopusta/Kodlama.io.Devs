using AutoMapper;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaioDevs.Application.Features.Technologies.Dtos;
using KodlamaioDevs.Application.Features.Technologies.Models;
using KodlamaioDevs.Application.Features.Technologies.Queries.GetListTechnology;
using KodlamaioDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();


            CreateMap<Technology, TechnologyListDto>().ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(t => t.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}
