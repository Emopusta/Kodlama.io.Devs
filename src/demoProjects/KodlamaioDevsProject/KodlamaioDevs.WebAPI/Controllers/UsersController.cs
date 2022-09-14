using KodlamaioDevs.Application.Features.Users.Commands.LoginUser;
using KodlamaioDevs.Application.Features.Users.Commands.RegisterUser;
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
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand createUserCommand)
        {
            RegisteredUserDto result = await Mediator.Send(createUserCommand);
            return Ok(result); 
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] LoginUserCommand loginUserCommand)
        {
            UserLoginDto result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
