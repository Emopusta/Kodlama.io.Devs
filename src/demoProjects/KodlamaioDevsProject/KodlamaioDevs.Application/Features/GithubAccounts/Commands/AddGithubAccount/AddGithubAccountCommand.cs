using KodlamaioDevs.Application.Features.GithubAccounts.Dtos;
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
            public Task<AddedGithubAccountDto> Handle(AddGithubAccountCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
