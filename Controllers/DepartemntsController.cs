using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.DTO;
using School.Models;
using System.ComponentModel.Design.Serialization;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartemntsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartemntsController()
        {
            _context = new AppDbContext();
        }


        [HttpGet("{Id}")]
        public IActionResult GetDepartmentById(int Id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == Id);
            if (department == null)
            {
                return NotFound("Id does not exist.");
            }
            var departmentDto = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };



            return Ok(departmentDto);
        }


        [HttpPost]

        public ActionResult<Department> CreateDepartment(CreateDeptDto department)
        {

            var departmentdb = new Department
            {
                Name = department.Name, 
                Description = department.Description
            };  
            _context.Departments.Add(departmentdb);
            _context.SaveChanges();
            return Created();

        }




        [HttpGet]

        public IActionResult GetAllDepartment()
        {
            var departments = _context.Departments.ToList();

            if(departments == null || departments.Count == 0)
            {
                return NotFound("No departments found.");
            }

           var deptdto = new List<DepartmentDto>();


            foreach (var department in departments)
            {
                var departmentDto = new DepartmentDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    Description = department.Description
                };
                deptdto.Add(departmentDto);
            }
            return Ok(deptdto);
        }

        [HttpPut("{id}")]
        
        public IActionResult UpdateDepartment(int id, CreateDeptDto dto)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);

            if(department == null)
                return NotFound("Department not found.");

            department.Name = dto.Name;
            department.Description = dto.Description;

            _context.SaveChanges();

            return NoContent();
        }

        //[HttpGet]
        //public IActionResult GetDepartemnts()
        //{

        //    var dept = _context.Departments.ToList();
        //    if (dept == null || dept.Count == 0)
        //    {
        //        return NotFound("No departments found.");
        //    }
        //    return Ok(dept);
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var dept = _context.Departments
        //        .FirstOrDefault(a => a.Id == id);

        //    return Ok(dept);
        //}
        //[HttpPost]
        //public IActionResult CreateDepartment(Department department)
        //{
        //    if (department == null)
        //    {
        //        return BadRequest("Department cannot be null.");
        //    }
        //    _context.Departments.Add(department);
        //    _context.SaveChanges();
        //    return CreatedAtAction(
        //        nameof(GetById),
        //        new { id = department.Id },
        //        department
        //        );
        //}




        //[HttpGet("Withdept")]
        
        //public IActionResult GetDeptWithTeacher()
        //{
        //    var m = _context.Departments.Include(t=>t.Teachers).ToList();
        //    return Ok(m);
        //}


        //[HttpPut]

        //public IActionResult UpdateDepartment(Department department, int id)
        //{
        //    if (department == null)
        //    {
        //        return BadRequest("Department cannot be null.");
        //    }


        //    var dept = _context.Departments.Find(id);
        //    if (dept == null)
        //    {
        //        return NotFound("DEp not ");
        //    }

        //    dept.Name = department.Name;
        //    dept.Description = department.Description;
           
            
        //    _context.SaveChanges();
        //    return NoContent();
        //}


        //[HttpPatch]
        //public IActionResult UpdateName(int id, string name)
        //{

        //    var dept = _context.Departments.Find(id);
        //    if (dept == null)
        //    {
        //        return NotFound("DEp not ");
        //    }

        //    dept.Name = name;
        //    _context.SaveChanges();
        //    return NoContent();



        //}



    }
}
