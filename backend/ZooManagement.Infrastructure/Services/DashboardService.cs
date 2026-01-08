using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Application.Dashboard;
using ZooManagement.Application.Interfaces;
using ZooManagement.Infrastructure.Persistence;

namespace ZooManagement.Infrastructure.Services;

public class DashboardService : IDashboardService
{
    private readonly ZooDbContext _context;

    public DashboardService(ZooDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardStats> GetStatsAsync()
    {
        var totalAnimals = await _context.Animals.CountAsync();
        var totalEnclosures = await _context.Enclosures.CountAsync();
        // Hier würden echte DB-Abfragen stehen
        return new DashboardStats
        {
            TotalAnimals = await _context.Animals.CountAsync(),
            TotalEnclosures = await _context.Enclosures.CountAsync(),
            TodayFeedings = await _context.FeedingSchedules.CountAsync(f => f.Date == DateTime.Today),
            // Beispiel-Werte für Änderungen
            AnimalChange = 5.2, 
            EnclosureChange = 0
        };
    }

    public async Task<List<RecentActivity>> GetRecentActivitiesAsync()
    {
        await Task.CompletedTask;
        return new List<RecentActivity>
        {
            new RecentActivity { Id = 1, Type = "Animal", Description = "Neuer Löwe hinzugefügt", Timestamp = DateTime.Now.AddHours(-2) },
            new RecentActivity { Id = 2, Type = "Feeding", Description = "Fütterung abgeschlossen", Timestamp = DateTime.Now.AddHours(-5) },
            new RecentActivity { Id = 3, Type = "Enclosure", Description = "Gehege gewartet", Timestamp = DateTime.Now.AddHours(-8) }
        };
    }
}