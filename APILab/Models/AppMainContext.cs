using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APILab.Models
{
    public class AppMainContext: IdentityDbContext<ApplicationUser>
    {
        public AppMainContext(DbContextOptions<AppMainContext> options): base(options)
        {
            DbContext
        }
        

        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
