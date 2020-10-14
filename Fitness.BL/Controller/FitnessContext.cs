
using Microsoft.EntityFrameworkCore;

using System.Data;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    class FitnessContext: DbContext
    {
        public static string connectionString = "adada";
        public FitnessContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Eating> Eatings { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<User> Users { get; set; }
 
    }
}
