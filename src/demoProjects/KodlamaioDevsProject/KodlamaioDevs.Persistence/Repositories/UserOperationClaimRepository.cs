using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using KodlamaioDevs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context):base(context)
        {

        }
    }
}
