using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.UserOperationClaims.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
    {
        public int Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaimToDelete = await _userOperationClaimRepository.GetAsync(uoc => uoc.Id == request.Id);

                if (userOperationClaimToDelete == null) throw new BusinessException("Boyle bir uoc yok.");

                UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaimToDelete);

                DeletedUserOperationClaimDto result = new()
                {
                    Id = deletedUserOperationClaim.Id,
                    OperationClaimId = deletedUserOperationClaim.OperationClaimId,
                    UserId = deletedUserOperationClaim.UserId
                };
                return result;
            }
        }
    }
}
