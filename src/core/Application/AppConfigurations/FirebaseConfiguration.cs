﻿namespace Application.AppConfigurations;
public class FirebaseConfiguration
{
    public string ApiKey { get; set; } = default!;
    public string Bucket { get; set; } = default!;
    public string ProjectId { get; set; } = default!;
    public string AuthEmail { get; set; } = default!;
    public string AuthPassword { get; set; } = default!;
}
