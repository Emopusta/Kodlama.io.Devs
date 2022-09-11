using Core.Application.Requests;
using KodlamaioDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaioDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaioDevs.Application.Features.Technologies.Dtos;
using KodlamaioDevs.Application.Features.Technologies.Models;
using KodlamaioDevs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaioDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("",result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }
    }
}
