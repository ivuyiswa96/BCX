using BCX.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCX.DAL
{
    public class DataContext :IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<LevelType> LevelTypes { get; set; }
    }
}
