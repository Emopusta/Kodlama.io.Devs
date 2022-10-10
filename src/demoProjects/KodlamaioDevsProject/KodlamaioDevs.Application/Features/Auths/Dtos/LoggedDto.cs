using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Auths.Dtos
{
    public class LoggedDto
    {
        public AccessToken AccessToken { get; set; }
    }
}
