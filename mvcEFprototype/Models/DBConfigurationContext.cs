using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace mvcEFprototype.Models
{
    public class DBConfigurationContext:DbContext
    {
        public DBConfigurationContext() :base("DefaultConnection") {
            //disable initializer 
            //disable change to DB
            // Database.SetInitializer<DBConfigurationContext>(null);
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Employee>().Property(f => f.DOB).HasColumnType("datetime2").HasPrecision(0);
        }
    }
}