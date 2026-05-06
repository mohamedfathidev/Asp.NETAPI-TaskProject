using APILab.Repos;
using Microsoft.AspNetCore.Mvc;

namespace APILab.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDepartmentRepo Departments { get; }
        IStudentRepo Students { get; }
        Task<int> SaveAllAsync(CancellationToken cancellationToken = default);

    }
}
