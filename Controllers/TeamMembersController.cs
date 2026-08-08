using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamMembersController : ControllerBase
{
    private readonly AppDbContext _context;

    public TeamMembersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers(int? id)
    {
        if (id == null || id == 0)
        {
            return await _context.TeamMembers
                .Take(5)
                .ToListAsync();
        }

        var teamMember = await _context.TeamMembers
            .FindAsync(id.Value);

        if (teamMember == null)
        {
            return NotFound();
        }

        return Ok(teamMember);
    }

    [HttpPost]
    public async Task<ActionResult<TeamMember>> CreateTeamMember(TeamMember teamMember)
    {
        _context.TeamMembers.Add(teamMember);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTeamMembers),
            new { id = teamMember.TeamMemberId },
            teamMember);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeamMember(
        int id,
        TeamMember teamMember)
    {
        if (id != teamMember.TeamMemberId)
        {
            return BadRequest();
        }

        _context.Entry(teamMember).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TeamMemberExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeamMember(int id)
    {
        var teamMember = await _context.TeamMembers.FindAsync(id);

        if (teamMember == null)
        {
            return NotFound();
        }

        _context.TeamMembers.Remove(teamMember);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TeamMemberExists(int id)
    {
        return _context.TeamMembers.Any(e => e.TeamMemberId == id);
    }
}