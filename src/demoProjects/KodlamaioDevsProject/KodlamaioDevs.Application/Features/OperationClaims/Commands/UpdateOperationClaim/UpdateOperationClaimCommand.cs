using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.OperationClaims.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto> , ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; } = { "admin" };

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaimToUpdate = await _operationClaimRepository.GetAsync(oc => oc.Id == request.Id);

                if (operationClaimToUpdate == null) throw new BusinessException("Boyle bir operationClaim yok.");


                operationClaimToUpdate.Name = request.Name;

                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaimToUpdate);

                UpdatedOperationClaimDto result = new()
                {
                    Id = operationClaimToUpdate.Id,
                    Name = operationClaimToUpdate.Name
                };
                return result;

            }
        }
    }
}
