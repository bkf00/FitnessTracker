using FitnessTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public class FitnessTrackerDbContext :DbContext
    {
        public DbSet<User> Users    { get; set; }  
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB\\Databases; Initial Catalog=FitnessDB; Encrypt=True;");
        }
    }
}
