using System.Diagnostics;
using Application.Toilets;
using Domain;
using Microsoft.AspNetCore.Authorization;
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
        return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateToilet(Toilet toilet)
    {
        return Ok(await Mediator.Send(new Create.Command {Toilet=toilet}));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditToilet(Guid id, Toilet toilet)
    {
        toilet.Id = id;
        return Ok(await Mediator.Send(new Edit.Command{Toilet=toilet}));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteToilet(Guid id)
    {
        return Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }
}