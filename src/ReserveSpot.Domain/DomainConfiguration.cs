using Microsoft.Extensions.DependencyInjection;

namespace ReserveSpot.Domain;
public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(
        this IServiceCollection services)
        => services;
}