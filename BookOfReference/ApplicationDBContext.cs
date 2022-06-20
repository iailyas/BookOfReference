using System;
using System.Collections.Generic;
using BookOfReference.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookOfReference
{
    public partial class ApplicationDBContext : DbContext
    {
        
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Departament> Departaments { get; set; } = null!;
        //public virtual DbSet<Position> Positions { get; set; } = null!;
        //public virtual DbSet<Salary> Salaries { get; set; } = null!;
        //public virtual DbSet<Worker> Workers { get; set; } = null!;

        
    }
}
