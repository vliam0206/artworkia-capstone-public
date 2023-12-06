using Application;
using Application.Commons;
using Infrastructure;
using Infrastructure.Database;
using WebApi.Extensions;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApiDocumentation(); // Add Swagger config

// Bind AppConfiguration from configuration
var config = builder.Configuration.Get<AppConfiguration>();
builder.Configuration.Bind(config);
builder.Services.AddSingleton(config!);

builder.Services.AddDbContext<AppDBContext>();

// Add extensions
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddServiceDIs();

// Add DI for IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add Cors
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles(); // Use static files

app.UseCorsPolicy(); // Use cors

app.UseAuthentication(); // Use Authentication

app.UseAuthorization();

app.MapControllers();

app.Run();
