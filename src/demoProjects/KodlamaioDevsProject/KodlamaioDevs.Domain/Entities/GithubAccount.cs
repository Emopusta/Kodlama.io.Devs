using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Domain.Entities
{
    public class GithubAccount : Entity
    {
        public int UserId { get; set; }
        public string GithubLink { get; set; }

        public GithubAccount()
        {

        }

        public GithubAccount(int id, int userId, string githubLink):base(id)
        {
            Id = id;
            UserId = userId;
            GithubLink = githubLink;
        }
    }
}
