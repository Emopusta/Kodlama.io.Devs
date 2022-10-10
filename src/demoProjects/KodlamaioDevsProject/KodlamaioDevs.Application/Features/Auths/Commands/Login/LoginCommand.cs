using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Auths.Dtos;
using KodlamaioDevs.Application.Features.Auths.Rules;
using KodlamaioDevs.Application.Services.AuthService;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoggedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailMustExistWhenRequested(request.UserForLoginDto.Email);

                User? userToLogin = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);


                if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt)) throw new BusinessException("Sifre yanlis.");

                LoggedDto loggedDto = new();

                

                AccessToken accessToken = await _authService.CreateAccessToken(userToLogin);

                


                loggedDto.AccessToken = accessToken;
                

                return loggedDto;


            }
        }
    }
}
