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
        [Route("report")]
        //[Authorize(Roles = "Admin")]
        public class ReportController : Controller
        {
            private readonly DataDbContext _context;

            public ReportController(DataDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            [Route("")]
            public async Task<ActionResult<IEnumerable<Report>>> GetReports()
            {
                return await _context.Reports.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Report>> GetReport(Guid id)
            {
                var report = await _context.Reports.FindAsync(id);

                if (report == null)
                {
                    return NotFound();
                }

                return Ok(report);
            }

            [HttpPost("{userId}")]
            public async Task<ActionResult<Report>> PostReports(Guid userId, CreateReportViewModel model)
            {
                Report createReport = new Report()
                {
                    Content = model.Content,
                    DetectionTime = DateTime.Now,
                    Place = model.Place,
                    CreatedBy = userId,
                    CreatedAt = DateTime.Now
                };
                _context.Reports.Add(createReport);
                await _context.SaveChangesAsync();

                return Ok(createReport);
            }


            [HttpPut("{id}/{userId}")]
            public async Task<IActionResult> PutReport(Guid id, Guid userId, UpdateReportViewModel model)
            {
                Report updateReport = new Report()
                {
                    Id = id,
                    Content = model.Content,
                    DetectionTime = DateTime.Now,
                    Place = model.Place,
                    CreatedBy = userId,
                    CreatedAt = DateTime.Now
                };
                _context.Entry(updateReport).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(updateReport);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<Report>> DeleteReport(Guid id)
            {
                var report = await _context.Reports.FindAsync(id);
                if (report == null)
                {
                    return NotFound();
                }

                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();

                return Ok();
            }

            private bool ReportsExists(Guid id)
            {
                return _context.Reports.Any(e => e.Id == id);
            }

        }
    }

