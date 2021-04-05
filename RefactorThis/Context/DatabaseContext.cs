using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RefactorThis.Models.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace RefactorThis.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("ProductsDb");
            optionsBuilder.UseSqlite(connectionString);
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDto>()
                .HasMany<ProductOptionsDto>()
                .WithOne()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }*/
    }
}
