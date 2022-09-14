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

namespace KodlamaioDevs.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisteredUserDto>
    {
        public RegisteredUserDto userForRegisterDto { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<RegisteredUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {

                User mappedUser = _mapper.Map<User>(request.userForRegisterDto);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.userForRegisterDto.Password, out passwordHash, out passwordSalt);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.Status = true;


                User createdUser = await _userRepository.AddAsync(mappedUser);

                UserOperationClaim userOperationClaim = new UserOperationClaim();
                userOperationClaim.OperationClaimId = 1; // User role
                userOperationClaim.UserId = createdUser.Id;
                await _userOperationClaimRepository.AddAsync(userOperationClaim);

                RegisteredUserDto createdUserDto = _mapper.Map<RegisteredUserDto>(createdUser);
                return createdUserDto;
            }
        }

    }
}
