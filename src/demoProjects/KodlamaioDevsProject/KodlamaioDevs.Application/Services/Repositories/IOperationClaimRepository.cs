using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaioDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Services.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
    }
}
