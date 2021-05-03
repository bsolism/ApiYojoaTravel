using System;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext
{
    public class ApiDataContext : DbContext
    {
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Classification> Classification { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PackageByActivity> PackageByActivity { get; set; }
        public DbSet<PackageByCategory> PackageByCategory { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BSOLIS; DataBase=ProjectYojoaTravel; Trusted_Connection=True;");
        }
    }
}