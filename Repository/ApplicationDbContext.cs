using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
