using Domain.Entities.Commons;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class ServiceModel 
{
    [MaxLength(150)]
    public string ServiceName { get; set; } = default!;
    [MaxLength(1000)]
    public string Description { get; set; } = default!;
    [MaxLength(150)]
    public string DeliveryTime { get; set; } = default!;
    public int NumberOfConcept { get; set; } = default!;
    public int NumberOfRevision { get; set; } = default!;
    public double StartingPrice { get; set; } = default!;
    public IFormFile Thumbnail { get; set; } = default!;
}
public class ServiceEM
{
    [MaxLength(150)]
    public string ServiceName { get; set; } = default!;
    [MaxLength(1000)]
    public string Description { get; set; } = default!;
    [MaxLength(150)]
    public string DeliveryTime { get; set; } = default!;
    public int NumberOfConcept { get; set; } = default!;
    public int NumberOfRevision { get; set; } = default!;
    public double StartingPrice { get; set; } = default!;
    public IFormFile Thumbnail { get; set; } = default!;
}
