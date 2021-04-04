using Microsoft.EntityFrameworkCore;
using RefactorThis.Models;

namespace RefactorThis.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ProductDto> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=App_Data/products.db");
        }
    }
}
