using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserMustExistWhenRequested(User user)
        {
            if (user == null) throw new BusinessException("User must exist.");
        }

        public async Task UserVerifyBusinessRule(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
        }
    }
}
