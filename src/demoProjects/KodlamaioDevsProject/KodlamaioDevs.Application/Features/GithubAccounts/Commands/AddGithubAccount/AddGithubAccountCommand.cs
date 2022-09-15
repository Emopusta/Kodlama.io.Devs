using AutoMapper;
using KodlamaioDevs.Application.Features.GithubAccounts.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.GithubAccounts.Commands.AddGithubAccount
{
    public class AddGithubAccountCommand : IRequest<AddedGithubAccountDto>
    {
        public AddedGithubAccountDto AddedGithubAccountDto { get; set; }

        public class AddGitbubAccountCommandHandler : IRequestHandler<AddGithubAccountCommand, AddedGithubAccountDto>
        {
            IGithubAccountRepository _accountRepository;
            IMapper _mapper;

            public AddGitbubAccountCommandHandler(IGithubAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }

            public async Task<AddedGithubAccountDto> Handle(AddGithubAccountCommand request, CancellationToken cancellationToken)
            {


                GithubAccount mappedGithubAccount = _mapper.Map<GithubAccount>(request.AddedGithubAccountDto);
                GithubAccount addedGithubAccount = await _accountRepository.AddAsync(mappedGithubAccount);
                AddedGithubAccountDto result = _mapper.Map<AddedGithubAccountDto>(addedGithubAccount);
                return result;
            }
        }
    }
}
