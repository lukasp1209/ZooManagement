using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Interfaces;

namespace ZooManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("stats")]
    public async Task<ActionResult<object>> GetDashboardStats()
    {
        var stats = await _dashboardService.GetStatsAsync();
        return Ok(stats);
    }

    [HttpGet("recent-activities")]
    public async Task<ActionResult<object>> GetRecentActivities([FromQuery] int limit = 10)
    {
        var activities = await _dashboardService.GetRecentActivitiesAsync();
        return Ok(activities);
    }
}