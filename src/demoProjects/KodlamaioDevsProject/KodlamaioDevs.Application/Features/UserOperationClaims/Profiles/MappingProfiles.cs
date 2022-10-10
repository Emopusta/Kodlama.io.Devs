using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.UserOperationClaims.Dtos;
using KodlamaioDevs.Application.Features.UserOperationClaims.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                .ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email))
                .ForMember(c => c.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name)).ReverseMap();

        }
    }
}
