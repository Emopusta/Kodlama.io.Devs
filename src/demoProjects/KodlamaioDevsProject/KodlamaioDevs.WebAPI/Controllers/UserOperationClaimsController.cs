using Core.Application.Requests;
using KodlamaioDevs.Application.Features.OperationClaims.Models;
using KodlamaioDevs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using KodlamaioDevs.Application.Features.UserOperationClaims.Commands.AddUserOperationClaim;
using KodlamaioDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using KodlamaioDevs.Application.Features.UserOperationClaims.Dtos;
using KodlamaioDevs.Application.Features.UserOperationClaims.Models;
using KodlamaioDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;
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
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest, int userId)
        {
            GetByUserIdUserOperationClaimQuery getByUserIdUserOperationClaimQuery = new() { PageRequest = pageRequest , UserId = userId };
            UserOperationClaimListModel result = await Mediator.Send(getByUserIdUserOperationClaimQuery);
            return Ok(result);
        }
    }
}
