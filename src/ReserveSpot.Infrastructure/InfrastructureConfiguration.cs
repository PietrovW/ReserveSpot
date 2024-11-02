using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ReserveSpot.Infrastructure.Persistence;
using ReserveSpot.Infrastructure.Shared;
using ReserveSpot.Application.Shared.Interfaces;
using ReserveSpot.Infrastructure.Services;

namespace ReserveSpot.Infrastructure;
public static class InfrastructureConfiguration
{
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddHttpContextAccessor()
            .AddSingleton<ICurrentUserService, CurrentUserService>()
            .AddSingleton<IDateTime,DateTimeService>()
            .AddDBStorage<ReserveSpotDbContext>(
                configuration,
                Assembly.GetExecutingAssembly());
        }
}
