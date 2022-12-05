using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;

public class ToiletsController:BaseApiController
{
    private readonly DataContext _context;

    public ToiletsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Toilet>>> GetToilets()
    {
        return await _context.Toilets.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Toilet>> GetToilet(Guid id)
    {
        return await _context.Toilets.FindAsync(id);
    }
    // [HttpPost]
    // [HttpPut]
    // [HttpDelete]
}