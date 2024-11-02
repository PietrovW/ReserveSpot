using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReserveSpot.Application.Shared.Interfaces;
using ReserveSpot.Domain.Shared;
using System.Reflection;

namespace ReserveSpot.Infrastructure.Shared;
internal static class InfrastructureConfiguration
{
    public static IServiceCollection AddDBStorage<TDbContext>(
       this IServiceCollection services,
       IConfiguration configuration,
       Assembly assembly)
       where TDbContext : DbContext
       => services
           .AddDatabase<TDbContext>(configuration)
           .AddRepositories(assembly);

    private static IServiceCollection AddDatabase<TDbContext>(
       this IServiceCollection services,
       IConfiguration configuration)
       where TDbContext : DbContext
       => services
           .AddScoped<DbContext, TDbContext>()
           .AddDbContext<TDbContext>(options => options
               .UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                   sqlOptions => sqlOptions
                       .MigrationsAssembly(
                           typeof(TDbContext).Assembly.FullName)));

    internal static IServiceCollection AddRepositories(
        this IServiceCollection services,
        Assembly assembly)
    {
        return services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IDomainRepository<>))
                    .AssignableTo(typeof(IQueryRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
    }
}

