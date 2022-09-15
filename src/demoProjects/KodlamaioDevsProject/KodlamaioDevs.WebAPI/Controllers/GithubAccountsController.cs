using KodlamaioDevs.Application.Features.GithubAccounts.Commands.AddGithubAccount;
using KodlamaioDevs.Application.Features.GithubAccounts.Commands.DeleteGithubAccount;
using KodlamaioDevs.Application.Features.GithubAccounts.Commands.UpdateGithubAccount;
using KodlamaioDevs.Application.Features.GithubAccounts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAccountsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGithubAccountCommand addGithubAccountCommand)
        {
            AddedGithubAccountDto result = await Mediator.Send(addGithubAccountCommand);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAccountCommand updateGithubAccountCommand)
        {
            UpdatedGithubAccountDto result = await Mediator.Send(updateGithubAccountCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubAccountCommand deleteGithubAccountCommand)
        {
            DeletedGithubAccountDto result = await Mediator.Send(deleteGithubAccountCommand);
            return Ok(result);
        }
          
    }
}
