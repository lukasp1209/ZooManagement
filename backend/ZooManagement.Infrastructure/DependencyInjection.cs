using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZooManagement.Application.Interfaces;
using ZooManagement.Infrastructure.Persistence;
using ZooManagement.Infrastructure.Repositories;

namespace ZooManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ZooDbContext>(options =>
            options.UseInMemoryDatabase("ZooDb"));

        services.AddScoped<IAnimalRepository, AnimalRepository>();

        return services;
    }
}