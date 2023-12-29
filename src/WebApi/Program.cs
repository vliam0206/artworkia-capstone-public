using Application;
using Application.Commons;
using Infrastructure;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using WebApi;
using WebApi.Extensions;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opt 
    => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApiDocumentation(); // Add Swagger config

// Bind AppConfiguration from configuration
var config = builder.Configuration.Get<AppConfiguration>();
builder.Configuration.Bind(config);
builder.Services.AddSingleton(config!);

// Add dbcontext middlerware
builder.Services.AddDbContextConfiguration(config!.ConnectionStrings.MSSQLServerDB);

// Add jwt configuration
builder.Services.AddJwtConfiguration(config!);

// Add extensions
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddServiceDIs();

// Add DI for IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add auto mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Cors
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseOpenApi(); // use swagger

app.UseHttpsRedirection();

app.UseStaticFiles(); // Use static files

app.UseCorsPolicy(); // Use cors

app.UseAuthentication(); // Use Authentication

app.UseAuthorization();

app.MapControllers();

app.Run();
