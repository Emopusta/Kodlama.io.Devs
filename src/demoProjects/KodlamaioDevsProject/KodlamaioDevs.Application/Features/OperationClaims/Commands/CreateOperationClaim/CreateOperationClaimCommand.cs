using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.OperationClaims.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto> , ISecuredRequest
    {
        public string Name { get; set; }
        public string[] Roles { get; } = { "admin" };

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim newOperationClaim = new()
                {
                    Name = request.Name
                };

                OperationClaim addedOperationClaim = await _operationClaimRepository.AddAsync(newOperationClaim);

                CreatedOperationClaimDto createdOperationClaimDto = new()
                {
                    Id = addedOperationClaim.Id,
                    Name = addedOperationClaim.Name
                };

                return createdOperationClaimDto;


            }
        }
    }
}
