using BookOfReference.Models;
using Microsoft.EntityFrameworkCore;

namespace BookOfReference
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Salary> Salary { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
       : base(options)
        {
        }

    }
}
