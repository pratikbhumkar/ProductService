using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RefactorThis.Models;
using RefactorThis.Models.DTO;

namespace RefactorThis.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<ProductOptionsDto> ProductOptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("ProductsDb");
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
