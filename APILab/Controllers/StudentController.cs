using APILab.Customs.CustomFilters;
using Microsoft.EntityFrameworkCore;
using APILab.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppMainContext _context;
        private readonly ILogger<StudentController> _logger;
        public StudentController(AppMainContext context, ILogger<StudentController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [ExceptionFilter]
        [ResTimeResultFilter]
        [Authorize(Roles = "Admin,Student")]
        public async  Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(10000, cancellationToken);
                var students = await _context.students
                                    .ToListAsync(cancellationToken);
                _logger.LogInformation("Return all students and Student count is {Count}", students.Count);
                return Ok(students);
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Request has been canceled by Client");
                return new EmptyResult();
            }
        }

        [HttpGet("{id:int}")]
        [ResTimeResultFilter]
        public IActionResult GetById(int id)
        {
            var student = _context.students.FirstOrDefault(s => s.Id == id);
            if(student == null)
            {
                _logger.LogError($"Student with id ({id}) not Found");
                return NotFound();
            }
            _logger.LogInformation($"return the student with id ({id})");
            return Ok(student);

        }
        [HttpGet("{name:alpha}")]
        [ResTimeResultFilter]
        public IActionResult GetByName(string name)
        {
            var student = _context.students.FirstOrDefault(s => s.Name == name);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [ResTimeResultFilter]
        public IActionResult Add(Student stu)
        {
            stu.Id = 0;
            _context.students.Add(stu);
            _context.SaveChanges();
            _logger.LogInformation($"Adding a new student with id {stu.Id}");
            return CreatedAtAction(nameof(GetById), new { id = stu.Id },  new { message = "Created Successfully", stu });
        }

        [HttpPut]
        [ResTimeResultFilter]
        public IActionResult Update(Student stu)
        {
            if(stu.Id == 0)
            {
                return BadRequest(new { message = "Id is required" });
            }
            var existing = _context.students.Find(stu.Id);
            if (existing == null)
                return NotFound(new { message = "Student not found" });

            existing.Name = stu.Name;
            existing.SSN = stu.SSN;
            existing.DateOfBirth = stu.DateOfBirth;
            existing.Address = stu.Address;
            existing.Image = stu.Image;
            existing.Level = stu.Level;


            //_context.students.Update(stu);
            _logger.LogInformation($"Update student with id =  ({stu.Id})");
            _context.SaveChanges();
            return Ok(new { message = "Updated successfully", data = stu });
        }

        [HttpDelete]
        [ResTimeResultFilter]
        public IActionResult Delete(Student stu)
        {
            if (stu.Id == 0)
            {
                return BadRequest(new { message = "Id is required" });
            }

            var existing = _context.students.Find(stu.Id);
            if (existing == null)
                return NotFound(new { message = "Student not found" });

            _context.students.Remove(stu);
            _context.SaveChanges();
            return Ok(stu);
        }


    }
}
