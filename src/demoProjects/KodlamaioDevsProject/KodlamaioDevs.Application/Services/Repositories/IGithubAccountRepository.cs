using Core.Persistence.Repositories;
using KodlamaioDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Services.Repositories
{
    public interface IGithubAccountRepository : IAsyncRepository<GithubAccount>, IRepository<GithubAccount>
    {
    }
}
