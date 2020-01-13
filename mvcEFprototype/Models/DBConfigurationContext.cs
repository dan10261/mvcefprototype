using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Employee>().Property(f => f.DOB).HasColumnType("datetime2").HasPrecision(0);
        }
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }
        private void AddTimestamps()
        {
            var entities = ChangeTracker
                           .Entries()
                           .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified) );
            var currentUserName = HttpContext.Current != null && HttpContext.Current.User != null?
                                  HttpContext.Current.User.Identity.Name:"Anonymous";
            foreach(var entityEntry in entities)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;
                ((BaseEntity)entityEntry.Entity).UpdatedBy = currentUserName;
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).CreatedBy = currentUserName;
                }
            }

        }

     
    }
}