using APILab.DTOs;
using APILab.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace APILab.Repos
{
    public class DepartmentRepo: GenericRepo<Department>, IDepartmentRepo
    {
        private readonly AppMainContext _context;
        public DepartmentRepo(AppMainContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<DepartmentWithEmployeesDto> GetDepartmentsWithStudents()
        {
            var departments = _context.departments.Include(d => d.Students).ToList();

            var result = departments.Adapt<List<DepartmentWithEmployeesDto>>();

            return result;
        }
    }
}
