using FitnessTracker.Data.ScaffoldContext;
using FitnessTracker.Api.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DomainUser = FitnessTracker.Domain.Entities.User;
using DataUser = FitnessTracker.Data.ScaffoldModels.User;

namespace FitnessTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly FitnessDbContext _context;

        public UsersController(FitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomainUser>>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users.Select(u => u.ToDomain()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DomainUser>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return Ok(user.ToDomain());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DomainUser user)
        {
            var entity = user.ToData();

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity.ToDomain());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, DomainUser user)
        {
            if (id != user.Id) return BadRequest();

            var entity = await _context.Users.FindAsync(id);
            if (entity == null) return NotFound();

            user.UpdateData(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
