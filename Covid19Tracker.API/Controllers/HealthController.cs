using Covid19Tracker.Data.DataContext;
using Covid19Tracker.Data.Entities;
using Covid19Tracker.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Covid19Tracker.API.Controllers
{
    [ApiController]
    [Route("health")]
    //[Authorize(Roles = "Admin")]
    public class HealthController : Controller
    {
        private readonly DataDbContext _context;

        public HealthController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Health>>> GetHealths()
        {
            return await _context.Healths.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Health>> GetHealth(Guid id)
        {
            var health = await _context.Healths.FindAsync(id);

            if (health == null)
            {
                return NotFound();
            }

            return Ok(health);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<Health>> PostHealths(Guid userId, CreateHealthViewModel model)
        {
            Health createHealth = new Health()
            {
                DateFollow = model.DateFollow,
                isDifficultyBreathing = model.isDifficultyBreathing,
                isFever = model.isFever,
                isCough = model.isCough,
                isSoreThroat = model.isSoreThroat,
                isPneumonia = model.isPneumonia,
                OtherSymptoms = model.OtherSymptoms,
                isTiredness = model.isTiredness,
                CreatedBy = userId,
                CreatedAt = DateTime.Now,
                Status = true
            };
            _context.Healths.Add(createHealth);
            await _context.SaveChangesAsync();

            return Ok(createHealth);
        }


        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> PutHealths(Guid id, Guid userId, UpdateHealthViewModel model)
        {
            Health updateHealth = new Health()
            {
                Id = id,
                DateFollow = model.DateFollow,
                isDifficultyBreathing = model.isDifficultyBreathing,
                isFever = model.isFever,
                isCough = model.isCough,
                isSoreThroat = model.isSoreThroat,
                isPneumonia = model.isPneumonia,
                OtherSymptoms = model.OtherSymptoms,
                isTiredness = model.isTiredness,
                CreatedBy = userId,
                CreatedAt = DateTime.Now,
                Status = true
            };
            _context.Entry(updateHealth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateHealth);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Health>> DeleteHealths(Guid id)
        {
            var health = await _context.Healths.FindAsync(id);
            if (health == null)
            {
                return NotFound();
            }

            _context.Healths.Remove(health);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool HealthsExists(Guid id)
        {
            return _context.Healths.Any(e => e.Id == id);
        }

    }
}
