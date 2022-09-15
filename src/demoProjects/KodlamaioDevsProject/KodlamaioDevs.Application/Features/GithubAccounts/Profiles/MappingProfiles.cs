using AutoMapper;
using KodlamaioDevs.Application.Features.GithubAccounts.Commands.AddGithubAccount;
using KodlamaioDevs.Application.Features.GithubAccounts.Commands.UpdateGithubAccount;
using KodlamaioDevs.Application.Features.GithubAccounts.Dtos;
using KodlamaioDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.GithubAccounts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAccount, AddGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, AddedGithubAccountDto>().ReverseMap();

            CreateMap<GithubAccount, UpdateGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, UpdatedGithubAccountDto>().ReverseMap();

            CreateMap<GithubAccount, UpdateGithubAccountCommand>().ReverseMap();
            CreateMap<GithubAccount, DeletedGithubAccountDto>().ReverseMap();


        }
    }
}
