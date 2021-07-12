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
    [Route("news")]
    //[Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private readonly DataDbContext _context;

        public NewsController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<News>>> GetHealths()
        {
            return await _context.News.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(Guid id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }
        [HttpPost("{userId}")]
        public async Task<ActionResult<News>> PostNews(Guid userId, CreateNewsViewModel model)
        {
            News createNews = new News()
            {
                Title = model.Title,
                Slug = model.Slug,
                Description = model.Description,
                Image = model.Image,
                Content = model.Content,
                ViewCount = model.ViewCount,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = userId
            };
            _context.News.Add(createNews);
            await _context.SaveChangesAsync();

            return Ok(createNews);
        }
        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> PutNews(int id, Guid userId, UpdateNewsViewModel model)
        {
            News updateNews = new News()
            {
                Id = id,
                Title = model.Title,
                Slug = model.Slug,
                Description = model.Description,
                Image = model.Image,
                Content = model.Content,
                ViewCount = model.ViewCount,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = userId
            };
            _context.Entry(updateNews).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateNews);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }

    }
