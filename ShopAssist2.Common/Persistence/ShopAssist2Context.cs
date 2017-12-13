using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShopAssist2.Common.Entities;
using ShopAssist2.Common.Migrations;

namespace ShopAssist2.Common.Persistence {
    public class ShopAssist2Context : DbContext {
        public ShopAssist2Context() : base("name=ShopAssist2ConnectionStringLocal") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopAssist2Context, Configuration>());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> StockItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionItem> TransactionItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Configuration.LazyLoadingEnabled = true;

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}