
using Microsoft.EntityFrameworkCore;

using System.Data;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Fitness.BL.Controller
{
    class FitnessContext: DbContext
    {
        //private string connectionString;

        //public FitnessContext() : base()
        //{
        //    var builder = new ConfigurationBuilder();
        //    builder.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).AddJsonFile("appsettings.json", optional: false);

        //    var configuration = builder.Build();

        //    connectionString = configuration.GetConnectionString("SQLConnection").ToString();

        //}


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=FitnessDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Eating> Eatings { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<User> Users { get; set; }
 
    }
}
