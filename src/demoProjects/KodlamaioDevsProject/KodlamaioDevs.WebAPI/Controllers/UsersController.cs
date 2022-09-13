using KodlamaioDevs.Application.Features.Users.Commands.CreateUserCommand;
using KodlamaioDevs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand createUserCommand)
        {
            CreatedUserDto result = await Mediator.Send(createUserCommand);
            return Ok(result); 
        }
    }
}
