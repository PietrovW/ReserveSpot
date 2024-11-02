using Microsoft.OpenApi.Models;

namespace ReserveSpot.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationSwagger(this IServiceCollection services, IConfiguration configuration)
    {
      
        services.AddEndpointsApiExplorer();
        //services.AddFluentValidationRulesToSwagger();
        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<SwaggerDefaultValues>();
            options.OperationFilter<SwaggerLanguageHeader>();
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Auth",
                Type = SecuritySchemeType.OAuth2,
                Reference = new OpenApiReference
                {
                   // Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                },
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                       
                        Scopes = new Dictionary<string, string>(),
                    }
                }
            };
            options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, Array.Empty<string>()}
            });

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Mercurius API",
                Version = "v1",
                Description = "Mercurius API",

            });
        });
        return services;
    }
    const string SwaggerRoutePrefix = "api-docs";
    public static IApplicationBuilder UseApplicationSwagger(this WebApplication app, IConfiguration configuration)
    {
        string resource = configuration["Keycloak:resource"]!;
        app.UseSwagger(options => { options.RouteTemplate = "api-docs/{documentName}/docs.json"; });
        app.UseSwaggerUI(options =>
        {
            options.OAuthClientId(resource);
            options.RoutePrefix = SwaggerRoutePrefix;
            foreach (var description in app.DescribeApiVersions())
                options.SwaggerEndpoint($"/{SwaggerRoutePrefix}/{description.GroupName}/docs.json", description.GroupName.ToUpperInvariant());
        });
        app.MapGet("/", () => Results.Redirect($"/swagger")).ExcludeFromDescription();
        return app;
    }
}
