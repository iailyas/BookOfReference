using BookOfReference.Models;
using Microsoft.EntityFrameworkCore;

namespace BookOfReference
{
    public partial class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Worker> Workers { get; set; }


    }
}
