using hrms_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hrms_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Leave> leaves { get; set; }
        public DbSet<Timesheet> timesheets { get; set; }
    }
}
