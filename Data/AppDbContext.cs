using hrms_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hrms_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Employee> employees { get; set; }
        DbSet<Leave> leaves { get; set; }
        DbSet<Timesheet> timesheets { get; set; }
    }
}
