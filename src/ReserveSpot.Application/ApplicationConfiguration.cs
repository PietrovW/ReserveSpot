using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ReserveSpot.Application;
public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) => services;
    
}