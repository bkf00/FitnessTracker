using FitnessTracker.Api.Dtos.User;
using FitnessTracker.Infrastructure.Context;
using FitnessTracker.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly FitnessDbContext _context;

    public UsersController(FitnessDbContext context)
    {
        _context = context;
    }

    // GET api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll()
    {
        return await _context.Users
            .Select(u => new UserReadDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Gender = u.Gender,
                Height = u.Height,
                Weight = u.Weight,
                RegistrationDate = u.RegistrationDate
            })
            .ToListAsync();
    }

    // GET api/users/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserReadDto>> Get(int id)
    {
        var user = await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new UserReadDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Gender = u.Gender,
                Height = u.Height,
                Weight = u.Weight,
                RegistrationDate = u.RegistrationDate
            })
            .FirstOrDefaultAsync();

        return user is null ? NotFound() : Ok(user);
    }

    // POST api/users
    [HttpPost]
    public async Task<ActionResult<UserReadDto>> Create(UserCreateDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            Height = dto.Height,
            Weight = dto.Weight
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = user.Id }, new UserReadDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            BirthDate = user.BirthDate,
            Gender = user.Gender,
            Height = user.Height,
            Weight = user.Weight,
            RegistrationDate = user.RegistrationDate
        });
    }


    // PUT api/users/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UserUpdateDto dto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null) return NotFound();

        user.Name = dto.Name;
        user.BirthDate = dto.BirthDate;
        user.Gender = dto.Gender;
        user.Height = dto.Height;
        user.Weight = dto.Weight;

        await _context.SaveChangesAsync();
        return NoContent();
    }


    // DELETE api/users/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null) return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
