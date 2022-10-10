using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaioDevs.Application.Features.UserOperationClaims.Models;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest{ get; set; }
        public int UserId { get; set; }

        public class GetByUserIdUserOperationClaimQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimListModel> Handle(GetByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim>? userOperationClaimList = await _userOperationClaimRepository.GetListAsync(uoc => uoc.UserId == request.UserId,
                    include: uoc => uoc.Include(u => u.User).Include(oc => oc.OperationClaim),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);



                UserOperationClaimListModel mappedResult = _mapper.Map<UserOperationClaimListModel>(userOperationClaimList);
                return mappedResult;

            }
        }
    }
}
