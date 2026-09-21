using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public StudentsController()
        {
            _context = new AppDbContext();
        }



        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.Include(c=>c.ClassRoom).ToList();

            return Ok(students);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);

            return Ok();
        }
    }
}
