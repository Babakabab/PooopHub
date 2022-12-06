using Application.Toilets;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ToiletsController:BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<Toilet>>> GetToilets()
    {
        return await Mediator.Send(new List.Query());

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Toilet>> GetToilet(Guid id)
    {
        return Ok();
    }
}