using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using KodlamaioDevs.Application.Features.Users.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<CreatedUserDto>
    {
        public CreatedUserDto userForRegisterDto { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {

                User mappedUser = _mapper.Map<User>(request.userForRegisterDto);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.userForRegisterDto.Password, out passwordHash, out passwordSalt);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;

                User createdUser = await _userRepository.AddAsync(mappedUser);

                CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(mappedUser);
                return createdUserDto;
            }
        }

    }
}
