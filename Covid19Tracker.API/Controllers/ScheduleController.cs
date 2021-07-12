using Covid19Tracker.Data.DataContext;
using Covid19Tracker.Data.Entities;
using Covid19Tracker.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Tracker.API.Controllers
{
    [ApiController]
    [Route("schedule")]
    //[Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        private readonly DataDbContext _context;

        public ScheduleController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(Guid id)
        {
            var schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<Schedule>> PostSchedules(Guid userId, CreateScheduleViewModel model)
        {
            Schedule createSchedule = new Schedule()
            {
                Content = model.Content,
                ScheduleDate = DateTime.Now,
                CreatedBy = userId,
                CreatedAt = DateTime.Now
            };
            _context.Schedules.Add(createSchedule);
            await _context.SaveChangesAsync();

            return Ok(createSchedule);
        }


        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> PutSchedule(Guid id, Guid userId, UpdateScheduleViewModel model)
        {
            Schedule updateSchedule = new Schedule()
            {
                Id = id,
                Content = model.Content,
                ScheduleDate = DateTime.Now,
                CreatedBy = userId,
                CreatedAt = DateTime.Now
            };
            _context.Entry(updateSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedulesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateSchedule);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Schedule>> DeleteSchedule(Guid id)
        {
            var report = await _context.Schedules.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(report);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool SchedulesExists(Guid id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }

    }
}
