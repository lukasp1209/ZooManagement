using ZooManagement.Application.Dashboard;

namespace ZooManagement.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardStats> GetStatsAsync();
    Task<List<RecentActivity>> GetRecentActivitiesAsync();
}