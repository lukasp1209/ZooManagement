using Microsoft.EntityFrameworkCore;
using ZooManagement.Domain.Animals;

namespace ZooManagement.Infrastructure.Persistence;

public class ZooDbContext : DbContext
{
    public DbSet<Animal> Animals => Set<Animal>();

    public ZooDbContext(DbContextOptions<ZooDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZooDbContext).Assembly);
    }
}