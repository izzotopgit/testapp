using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PwcTestApp.DL.Entities;

namespace PwcTestApp.DL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseConnection")
        {
            Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        public DbSet<HistoryEntry> HistoryEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}