using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context):base(context)
        {

        }
    }
}
