using DropdownBI.Data;
using DropdownBI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DropdownBI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EnrollsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetEnrollments(int id = 0, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    return BadRequest("Page number and page size must be greater than 0.");
                }

                var query = _context.Enrolls
                                   .Include(e => e.User)
                                   .AsQueryable();

                var courses = _context.Courses;
                Course? course = courses.FirstOrDefault(c => c.Id == id);

                string course_id = "No";

                if (course != null)
                {
                    course_id = course.CourseId!;
                }

                query = query.Where(e => e.CourseId == course_id);

                var totalItems = await query.CountAsync();
                var enrollments = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var pagedEnroll = new PagedList<Enroll>(enrollments, totalItems, pageNumber, pageSize);
                return Ok(pagedEnroll);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
