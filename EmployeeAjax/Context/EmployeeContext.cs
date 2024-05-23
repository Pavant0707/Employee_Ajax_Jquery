using EmployeeAjax.Repo;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAjax.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EntityEmployee> Employeedb {  get; set; }
    }
}
