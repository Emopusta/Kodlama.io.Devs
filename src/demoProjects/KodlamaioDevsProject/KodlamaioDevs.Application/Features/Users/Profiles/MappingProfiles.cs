using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Users.Commands.RegisterUser;
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
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, RegisteredUserDto>().ReverseMap();

            CreateMap<User, LoggedUserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<AccessToken, UserLoginDto>().ReverseMap();

        }
    }
}
