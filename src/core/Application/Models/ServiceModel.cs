using Domain.Entities.Commons;
using Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class ServiceModel 
{
    [MaxLength(150)]
    public string ServiceName { get; set; } = default!;
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    [MaxLength(150)]
    public string DeliveryTime { get; set; } = default!;
    [MaxLength(150)]
    public string NumberOfConcept { get; set; } = default!;
    [MaxLength(150)]
    public string NumberOfRevision { get; set; } = default!;
    public double StartingPrice { get; set; } = default!;
    public string CoverLocation { get; set; } = default!;
}
public class ServiceEM
{
    [MaxLength(150)]
    public string ServiceName { get; set; } = default!;
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    [MaxLength(150)]
    public string DeliveryTime { get; set; } = default!;
    [MaxLength(150)]
    public string NumberOfConcept { get; set; } = default!;
    [MaxLength(150)]
    public string NumberOfRevision { get; set; } = default!;
    public double StartingPrice { get; set; } = default!;
    public string CoverLocation { get; set; } = default!;
}
