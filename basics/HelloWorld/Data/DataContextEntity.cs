using Microsoft.EntityFrameworkCore;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextEntity : DbContext // Inherit information from DbContext (Entity Framework Class)
    {
        private IConfiguration _config;
        public DataContextEntity(IConfiguration config){
            _config = config;

        }
        //Tell Entity framework to connect to specific models with a "DbSet"
        public DbSet<Computer>? Computer {get; set;} // make nullable with "?", targets Computer table.

        protected override void OnConfiguring(DbContextOptionsBuilder options) // this will override the defualt DbContext OnConfiguring method
        {
            if(!options.IsConfigured)
            {
                //set configurations options.
                //this project is using SQL Server,
                // two args, connection string & callback to try again if it fails. 
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //sets default schema
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            //target a specific table & schema
            modelBuilder.Entity<Computer>()
            .HasKey(c => ((int)c.Price));
                // .HasNoKey();
                // .ToTable("Computer", "TutorialAppSchema");
                // .ToTable("tablename", "SchemaName");
        }
    }
}