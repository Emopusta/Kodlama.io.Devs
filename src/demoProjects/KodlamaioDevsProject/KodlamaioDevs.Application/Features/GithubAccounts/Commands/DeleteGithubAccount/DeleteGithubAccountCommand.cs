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

namespace KodlamaioDevs.Application.Features.GithubAccounts.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountCommand :IRequest<DeletedGithubAccountDto>
    {
        public int Id { get; set; }

        public class DeleteGithubAccountCommandHandler : IRequestHandler<DeleteGithubAccountCommand, DeletedGithubAccountDto>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;

            public DeleteGithubAccountCommandHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
            }

            public async Task<DeletedGithubAccountDto> Handle(DeleteGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount? githubAccountToDelete = await _githubAccountRepository.GetAsync(ga => ga.Id == request.Id);

                //rules

                GithubAccount mappedGithubAccount = _mapper.Map<GithubAccount>(githubAccountToDelete);
                GithubAccount deletedGithubAccount = await _githubAccountRepository.DeleteAsync(mappedGithubAccount);
                DeletedGithubAccountDto result = _mapper.Map<DeletedGithubAccountDto>(deletedGithubAccount);
                return result;
                
             }
        }
    }
}
