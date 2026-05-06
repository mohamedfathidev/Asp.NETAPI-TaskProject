using APILab.DTOs;
using APILab.Models;
using APILab.Repos;
using APILab.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //private readonly IDepartmentRepo _depRepo;
        private readonly IUnitOfWork _uow;

        public DepartmentController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getAllDepts")]
        public IActionResult GetAllDepts()
        {
            var departments = _uow.Departments.GetAll();

            return Ok(departments);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _uow.Departments.GetDepartmentsWithStudents();

            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var department = _uow.Departments.GetById(id);

            return Ok(department);
        }


        [HttpPost]
        public async Task<IActionResult> Add(Department department,CancellationToken cancellationToken)
        {
            _uow.Departments.Add(department);

            await _uow.SaveAllAsync(cancellationToken);

            return CreatedAtAction(
                nameof(GetById),  
                new { id = department.Id },
                department
            );
        }


    }
}
