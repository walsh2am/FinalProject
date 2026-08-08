using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HobbyController : ControllerBase
{
    private readonly AppDbContext _context;

    public HobbyController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hobby>>> GetHobbies(int? id)
    {
        if (id == null || id == 0)
        {
            return await _context.Hobby
                .Take(5)
                .ToListAsync();
        }

        var hobby = await _context.Hobby.FindAsync(id.Value);

        if (hobby == null)
        {
            return NotFound();
        }

        return Ok(hobby);
    }

    [HttpPost]
    public async Task<ActionResult<Hobby>> CreateHobby(Hobby hobby)
    {
        _context.Hobby.Add(hobby);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetHobbies),
            new { id = hobby.HobbyId },
            hobby);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHobby(
        int id,
        Hobby hobby)
    {
        if (id != hobby.HobbyId)
        {
            return BadRequest();
        }

        _context.Entry(hobby).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHobby(int id)
    {
        var hobby = await _context.Hobby.FindAsync(id);

        if (hobby == null)
        {
            return NotFound();
        }

        _context.Hobby.Remove(hobby);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}