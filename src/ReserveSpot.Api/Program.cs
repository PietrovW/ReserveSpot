

using System.Net;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Oakton;
using ReserveSpot.Infrastructure;
using Wolverine;
using Wolverine.FluentValidation;
using ReserveSpot.Application;
using ReserveSpot.Domain;
var builder = WebApplication.CreateBuilder(args);

var version1 = new ApiVersion(1);
var version2 = new ApiVersion(2);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers(mvcOptions => mvcOptions
    .AddResultConvention(resultStatusMap => resultStatusMap
        .AddDefaultMap()
        .For(ResultStatus.Ok, HttpStatusCode.OK, resultStatusOptions => resultStatusOptions
            .For("POST", HttpStatusCode.Created)
            .For("DELETE", HttpStatusCode.NoContent))
        .For(ResultStatus.Error, HttpStatusCode.InternalServerError)
    ));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseWolverine(options =>
{
    options.Discovery.IncludeAssembly(typeof(ReserveSpot.Application.ApplicationConfiguration).Assembly);
    options.UseFluentValidation();
    options.UseFluentValidation(RegistrationBehavior.ExplicitRegistration);
});
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new QueryStringApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));

}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
}).EnableApiVersionBinding();
builder.Services.AddDomain();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();
ApiVersionSet versionSet = app.NewApiVersionSet()
     .HasApiVersion(version1)
     .HasApiVersion(version2)
     .ReportApiVersions()
     .Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.UseHttpsRedirection();
///app.UseApiExceptionHandling();

return await app.RunOaktonCommands(args);
