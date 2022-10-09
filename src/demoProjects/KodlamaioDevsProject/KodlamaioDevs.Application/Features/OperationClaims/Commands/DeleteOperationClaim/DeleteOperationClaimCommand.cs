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

namespace KodlamaioDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaimToDelete = await _operationClaimRepository.GetAsync(oc => oc.Id == request.Id);

                if (operationClaimToDelete == null) throw new BusinessException("Boyle bir operationClaim yok.");

                OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaimToDelete);

                DeletedOperationClaimDto result = new()
                {
                    Id = operationClaimToDelete.Id,
                    Name = operationClaimToDelete.Name
                };
                return result;
                
            }
        }
    }
}
