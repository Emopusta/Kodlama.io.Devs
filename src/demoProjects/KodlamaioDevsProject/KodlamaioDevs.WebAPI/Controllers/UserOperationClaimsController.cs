using KodlamaioDevs.Application.Features.UserOperationClaims.Commands.AddUserOperationClaim;
using KodlamaioDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using KodlamaioDevs.Application.Features.UserOperationClaims.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserOperationClaimCommand addUserOperationClaimCommand)
        {
            AddedUserOperationClaimDto addedUserOperationClaimDto = await Mediator.Send(addUserOperationClaimCommand);
            return Ok(addedUserOperationClaimDto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto deletedUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(deletedUserOperationClaimDto);
        }
    }
}
