using APILab.Models;
using APILab.Repos;
using Microsoft.AspNetCore.Mvc;

namespace APILab.UnitOfWork
{
    public class UOW: IUnitOfWork
    {
        private readonly AppMainContext _context;

        public IDepartmentRepo Departments { get; }
        public IStudentRepo Students { get; }

        public UOW(AppMainContext context)
        {
            _context = context;

            Departments = new DepartmentRepo(_context);
            Students = new StudentRepo(_context);
        }

        public async Task<int> SaveAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
