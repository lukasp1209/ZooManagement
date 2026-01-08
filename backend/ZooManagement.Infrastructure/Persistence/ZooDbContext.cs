using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Domain.Animals;
using ZooManagement.Domain.Enclosures;
using ZooManagement.Domain.Feedings;

namespace ZooManagement.Infrastructure.Persistence;

public class ZooDbContext : DbContext
{
    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<Enclosure> Enclosures => Set<Enclosure>();
    public DbSet<Activity> Activities => Set<Activity>();
    public DbSet<FeedingSchedule> FeedingSchedules => Set<FeedingSchedule>();

    public ZooDbContext(DbContextOptions<ZooDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZooDbContext).Assembly);
    }
}