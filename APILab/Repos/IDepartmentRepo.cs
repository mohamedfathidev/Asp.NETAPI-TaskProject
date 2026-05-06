using APILab.DTOs;
using APILab.Models;

namespace APILab.Repos
{
    public interface IDepartmentRepo: IGenericRepo<Department>
    {

        IEnumerable<DepartmentWithEmployeesDto> GetDepartmentsWithStudents();
    }
}
