using ASPNETMVCCORE.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCORE.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
