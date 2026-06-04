using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed a few rows inside the migration so the page shows data immediately.
        var seedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Keyboard", Description = "Mechanical keyboard", Price = 79.99m, CreatedAt = seedDate },
            new Product { Id = 2, Name = "Mouse", Description = "Wireless mouse", Price = 29.50m, CreatedAt = seedDate },
            new Product { Id = 3, Name = "Monitor", Description = "27-inch 1440p display", Price = 249.00m, CreatedAt = seedDate },
            new Product { Id = 4, Name = "Desk Lamp", Description = "LED desk lamp", Price = 19.95m, CreatedAt = seedDate }
        );
    }
}
