using Microsoft.EntityFrameworkCore;
using StockProductLibrary;
using Microsoft.Extensions.Configuration;

namespace StockProductLibraryContext
{
    public class StockProductContext : DbContext
    {
        static DbContextOptions<StockProductContext> _options;

        static StockProductContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<StockProductContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }
        public StockProductContext()
            : base(_options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
