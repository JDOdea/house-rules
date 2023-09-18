using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRules.Data;
using Microsoft.EntityFrameworkCore;
using HouseRules.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseRules.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoreController : ControllerBase
{
    private HouseRulesDbContext _dbContext;

    public ChoreController(HouseRulesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Chores.ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Chore chore = _dbContext.Chores
            .Include(c => c.ChoreAssignments)
            .ThenInclude(ca => ca.UserProfile)
            .Include(c => c.ChoreCompletions)
            .SingleOrDefault(c => c.Id == id);

        if (chore == null)
        {
            return NotFound();
        }

        return Ok(chore);
    }

    [HttpPost("{id}/complete")]
    [Authorize]
    public IActionResult CompleteChore(int id, int userId)
    {
        Chore choreToComplete = _dbContext.Chores
            .Include(c => c.ChoreAssignments)
            .ThenInclude(ca => ca.UserProfile)
            .SingleOrDefault(c => c.Id == id);

        if (choreToComplete == null)
        {
            return NotFound();
        }

        _dbContext.ChoreCompletions.Add(new ChoreCompletion
        {
            UserProfileId = userId,
            ChoreId = id,
            CompletedOn = DateTime.Now
        });

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateChore(Chore chore)
    {
        _dbContext.Chores.Add(chore);
        _dbContext.SaveChanges();
        return Created($"/api/chore/{chore.Id}", chore);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateChore(int id, Chore updatedChore)
    {
        Chore chore = _dbContext.Chores.SingleOrDefault(c => c.Id == id);

        if (chore == null)
        {
            return NotFound();
        }

        chore.Name = updatedChore.Name;
        chore.Difficulty = updatedChore.Difficulty;
        chore.ChoreFrequencyDays = updatedChore.ChoreFrequencyDays;
        chore.ChoreAssignments = updatedChore.ChoreAssignments;
        chore.ChoreCompletions = updatedChore.ChoreCompletions;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteChore(int id)
    {
        Chore chore = _dbContext.Chores.SingleOrDefault(c => c.Id == id);

        if (chore == null)
        {
            return NotFound();
        }
        _dbContext.Chores.Remove(chore);

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("{id}/assign")]
    [Authorize(Roles = "Admin")]
    public IActionResult AssignChore(int id, int userId)
    {
        Chore chore = _dbContext.Chores.SingleOrDefault(c => c.Id == id);
        UserProfile userProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == userId);

        if (chore == null || userProfile == null)
        {
            return NotFound();
        }

        _dbContext.ChoreAssignments.Add(new ChoreAssignment
        {
            UserProfileId = userId,
            ChoreId = id
        });

        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("{id}/unassign")]
    [Authorize(Roles = "Admin")]
    public IActionResult UnassignChore(int id, int userId)
    {
        Chore chore = _dbContext.Chores.SingleOrDefault(c => c.Id == id);
        UserProfile userProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == userId);
        ChoreAssignment choreAssignment = _dbContext.ChoreAssignments
            .SingleOrDefault(ca => ca.ChoreId == id && ca.UserProfileId == userId);

        if (chore == null || userProfile == null || choreAssignment == null)
        {
            return NotFound();
        }

        _dbContext.ChoreAssignments.Remove(choreAssignment);
        _dbContext.SaveChanges();
        return NoContent();
    }
}