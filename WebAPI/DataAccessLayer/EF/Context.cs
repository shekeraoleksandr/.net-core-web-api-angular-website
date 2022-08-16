using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EF
{
    public class Context : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public Context()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmployeeDB;Trusted_Connection=True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
