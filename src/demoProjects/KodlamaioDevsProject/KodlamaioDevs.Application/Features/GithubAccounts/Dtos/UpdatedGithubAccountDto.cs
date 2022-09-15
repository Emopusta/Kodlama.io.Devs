using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.GithubAccounts.Dtos
{
    public class UpdatedGithubAccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubLink { get; set; }

    }
}
