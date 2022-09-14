using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Users.Dtos;
using KodlamaioDevs.Application.Features.Users.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserLoginDto>
    {
        public LoggedUserDto LoggedUserDto { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UserLoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                
                User? userToLogin = await _userRepository.GetAsync(u => u.Email == request.LoggedUserDto.Email);


                await _userBusinessRules.UserMustExistWhenRequested(userToLogin);

                await _userBusinessRules.UserVerifyBusinessRule(request.LoggedUserDto.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt);

                List<OperationClaim> operationClaims = (await _userOperationClaimRepository.GetListAsync(oc => oc.UserId == userToLogin.Id, include:
                                                            p => p.Include(a => a.OperationClaim))).Items.Select(b => b.OperationClaim).ToList(); // -----------

                AccessToken accessToken = _tokenHelper.CreateToken(userToLogin, operationClaims);

                UserLoginDto userLoginDto = _mapper.Map<UserLoginDto>(accessToken);
               
                return userLoginDto;
            }
        }
    }
}
