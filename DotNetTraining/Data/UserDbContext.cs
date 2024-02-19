using DotNetTraining.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;



namespace DotNetTraining.Data
{
    public class UserDbContext : DbContext
    {
        string connectionString = ConfigurationManager.ConnectionStrings["UserDbContext"].ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}