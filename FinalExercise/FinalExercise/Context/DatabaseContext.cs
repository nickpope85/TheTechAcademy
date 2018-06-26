using FinalExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FinalExercise.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("StudentDatabase")
        { }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>().Property(p => p.FirstName).HasColumnName("First Name");
        }
    }
}