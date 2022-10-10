using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.UserOperationClaims.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.UserOperationClaims.Commands.AddUserOperationClaim
{
    public class AddUserOperationClaimCommand : IRequest<AddedUserOperationClaimDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public int UserOperationClaimId { get; set; }

        public string[] Roles { get; } = {"admin"};

        public class AddUserOperationClaimCommandHandler : IRequestHandler<AddUserOperationClaimCommand, AddedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public AddUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AddedUserOperationClaimDto> Handle(AddUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaimToAdd = new()
                {
                    OperationClaimId = request.UserOperationClaimId,
                    UserId = request.UserId
                };

                UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaimToAdd);

                AddedUserOperationClaimDto addedUserOperationClaimDto = new()
                {
                    OperationClaimId = addedUserOperationClaim.OperationClaimId,
                    UserId = addedUserOperationClaim.UserId
                };
                return addedUserOperationClaimDto;
            }
        }
    }
}
