﻿using Domain.Entitites;

namespace Application.Models;

public class ServiceVM
{
    public Guid Id { get; set; }
    public string ServiceName { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public string DeliveryTime { get; set; } = default!;
    public string NumberOfConcept { get; set; } = default!;
    public string NumberOfRevision { get; set; } = default!;
    public double StartingPrice { get; set; } = default!;
    public string CoverLocation { get; set; } = default!;
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModificatedBy { get; set; }
    public DateTime? LastModificatedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }

    public Account Account { get; set; } = default!;
    public List<Request> Requests { get; set; } = default!;
    public List<Proposal> Proposals { get; set; } = default!;
    public List<ServiceDetail> ServiceDetails { get; set; } = default!;
    public List<CategoryServiceDetail> CategoryServiceDetails { get; set; } = default!;
}