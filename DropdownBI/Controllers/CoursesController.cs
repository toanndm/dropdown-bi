using DropdownBI.Data;
using DropdownBI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DropdownBI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<PagedList<Course>>> GetCourses([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var courses = await _context.Courses
                    .OrderBy(c => c.Id)
                    .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

                var totalItems = await _context.Courses.CountAsync();

                var pagedCourses = new PagedList<Course>(courses, totalItems, page, pageSize);

                return Ok(pagedCourses);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
