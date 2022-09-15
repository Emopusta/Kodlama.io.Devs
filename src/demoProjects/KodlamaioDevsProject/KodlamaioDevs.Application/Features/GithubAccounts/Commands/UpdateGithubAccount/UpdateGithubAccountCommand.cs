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

namespace KodlamaioDevs.Application.Features.GithubAccounts.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountCommand : IRequest<UpdatedGithubAccountDto>
    {
        public UpdatedGithubAccountDto GithubAccountToUpdate { get; set; }

        public class UpdateGithubAccountCommandHandler : IRequestHandler<UpdateGithubAccountCommand, UpdatedGithubAccountDto>
        {
            IGithubAccountRepository _githubAccountRepository;
            IMapper _mapper;

            public UpdateGithubAccountCommandHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedGithubAccountDto> Handle(UpdateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount? githubAccountToUpdate =  await _githubAccountRepository.GetAsync(ga => ga.Id == request.GithubAccountToUpdate.Id);

                // rule

                GithubAccount mappedGithubAccount = _mapper.Map(request.GithubAccountToUpdate, githubAccountToUpdate);
                GithubAccount updatedGithubAccount = await _githubAccountRepository.UpdateAsync(mappedGithubAccount);
                UpdatedGithubAccountDto result = _mapper.Map<UpdatedGithubAccountDto>(updatedGithubAccount);
                return result;

            }
        }
    }
}
