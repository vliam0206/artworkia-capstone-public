
using Application.Models;
using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System.Diagnostics;

namespace Application.Services.ELK;

public static class ElasticSearchExtensions
{
    public static bool AddElasticSearch(
        this IServiceCollection services, IConfiguration configuration)
    {
        string uri = configuration["ELKConfiguration:Uri"] ?? default!;
        string defaultIndex = configuration["ELKConfiguration:Index"] ?? default!;
        string username = configuration["ELKConfiguration:Username"] ?? default!;
        string password = configuration["ELKConfiguration:Password"] ?? default!;

        var setting = new ConnectionSettings(new Uri(uri))
            .BasicAuthentication(username, password)
            .DefaultIndex(defaultIndex)
            .EnableDebugMode()
            .EnableApiVersioningHeader();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var client = new ElasticClient(setting);
        while (!client.Ping().IsValid) { 
            Task.Delay(1000);
            if (stopwatch.Elapsed.TotalSeconds > 20)
            {
                return false;
            }
        }

        Console.WriteLine(client.Ping().ToString() + ": ElasticSearch is connected =====================");

        AddDefaultMappings(setting);
        services.AddSingleton<IElasticClient>(client);

        CreateIndex(client, defaultIndex);
        return true;
    }

    public static IApplicationBuilder UseInitDataElasticSearch(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var artworkService = services.GetRequiredService<IArtworkService>();
        var client = services.GetRequiredService<IElasticClient>();
        var artworks = artworkService.GetAllArtworksAsync().Result;

        var bulkIndexResponse = client.Bulk(b => b
            .Index("artworksv2")
            .IndexMany(artworks)
        );

        return app;
    }

    private static void AddDefaultMappings(ConnectionSettings settings)
    {
        //settings.DefaultMappingFor<ArtworksV2>(x => x.Ignore(x => x.IsAIGenerated));
    }

    private static void CreateIndex(IElasticClient client, string indexName)
    {
        var result = client.Indices.Exists(indexName);
        if (!result.Exists)
        {
            client.Indices.Create(Indices.Index(indexName), c => c
            .Map<ArtworksV2>(m => m
                .AutoMap()
            )
        );
        }
    }
}
