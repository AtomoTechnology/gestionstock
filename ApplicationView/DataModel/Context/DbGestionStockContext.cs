using ApplicationView.DataModel.Configuration;
using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace ApplicationView.DataModel.Context
{
    public partial class DbGestionStockContext : DbContext
    {
        public DbGestionStockContext(DbContextOptions<DbGestionStockContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbGestionStockContext() : base()
        {
        }

        #region Dbset
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<IncreasePriceAfterTwelve> IncreasePriceAfterTwelves { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<HistoryPrice> HistoryPrices { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<OpenWorkTurn> OpenWorkTurns { get; set; }
        public DbSet<Turns> Turns { get; set; }
        public DbSet<SettingBusiness> SettingBusiness { get; set; }
        public DbSet<Legit> Legit { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleAccount> ModuleAccounts { get; set; }
        public DbSet<SubModule> SubModules { get; set; }
        public DbSet<SubModuleAccount> SubModuleAccounts { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionDetail> PromotionDetails { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
               UseSqlServer(StringgConnection.GetString());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new AccountConfiguration(modelBuilder.Entity<Account>());
            new BusinessConfiguration(modelBuilder.Entity<Business>());
            new ProviderConfiguration(modelBuilder.Entity<Provider>());
            new UserConfiguration(modelBuilder.Entity<User>());
            new RoleConfiguration(modelBuilder.Entity<Role>());
            new PaymentTypeConfiguration(modelBuilder.Entity<PaymentType>());
            new CategoryConfiguration(modelBuilder.Entity<Category>());
            new IncreasePriceAfterTwelveConfiguration(modelBuilder.Entity<IncreasePriceAfterTwelve>());
            new HistoryConfiguration(modelBuilder.Entity<History>());
            new SubCategoryConfiguration(modelBuilder.Entity<SubCategory>());
            new OpenWorkTurnConfiguration(modelBuilder.Entity<OpenWorkTurn>());
            new TurnsConfiguration(modelBuilder.Entity<Turns>());
            new SettingBusinessCongiguration(modelBuilder.Entity<SettingBusiness>());
            new ModuleConfiguration(modelBuilder.Entity<Module>());
            new ModuleAccountConfiguration(modelBuilder.Entity<ModuleAccount>());
            new SubModuleConfiguration(modelBuilder.Entity<SubModule>());
            new SubModuleAccountConfiguration(modelBuilder.Entity<SubModuleAccount>());
            new PromotionConfiguration(modelBuilder.Entity<Promotion>());
            new PromotionDetailConfiguration(modelBuilder.Entity<PromotionDetail>());
        }
    }

    public class DbGestionStockFactory: IDesignTimeDbContextFactory<DbGestionStockContext>
    {
        public DbGestionStockContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DbGestionStockContext>();
            optionBuilder.UseSqlServer(StringgConnection.GetString());
            return new DbGestionStockContext(optionBuilder.Options);
        }
    }
}
