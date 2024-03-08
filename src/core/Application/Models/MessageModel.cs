﻿using Domain.Entitites;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class MessageModel
{
    [Required]
    public Guid ReceiverId { get; set; }
    [MaxLength(1000)]
    public string? Text { get; set; }     // text or fileLocation not null at the same time
    public string? FileLocation { get; set; }
}

public class MessageVM
{
    public Guid ChatBoxId { get; set; }
    [MaxLength(1000)]
    public string? Text { get; set; }     // text or fileLocation not null at the same time
    public string? FileLocation { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
}