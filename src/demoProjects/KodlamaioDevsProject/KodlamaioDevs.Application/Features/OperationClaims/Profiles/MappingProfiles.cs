using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.OperationClaims.Dtos;
using KodlamaioDevs.Application.Features.OperationClaims.Models;
using KodlamaioDevs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using KodlamaioDevs.Application.Features.Technologies.Models;
using KodlamaioDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, GetListOperationClaimQuery>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        }
    }
}
