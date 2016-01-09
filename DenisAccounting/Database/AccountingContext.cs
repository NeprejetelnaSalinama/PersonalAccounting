using DenisAccounting.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DenisAccounting.Database
{
    public class AccountingContext : DbContext
    {

        public AccountingContext() : base("AccountingContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}