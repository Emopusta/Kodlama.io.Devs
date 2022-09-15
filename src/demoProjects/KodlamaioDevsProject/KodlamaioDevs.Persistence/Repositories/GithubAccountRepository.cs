using Core.Persistence.Repositories;
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
    public class GithubAccountRepository : EfRepositoryBase<GithubAccount, BaseDbContext>, IGithubAccountRepository
    {
        public GithubAccountRepository(BaseDbContext context):base(context)
        {

        }
    }
}
