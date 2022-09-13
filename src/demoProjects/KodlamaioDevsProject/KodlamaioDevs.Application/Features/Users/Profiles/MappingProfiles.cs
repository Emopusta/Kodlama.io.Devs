using AutoMapper;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.Users.Commands.CreateUserCommand;
using KodlamaioDevs.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreatedUserDto>().ReverseMap();
        }
    }
}
