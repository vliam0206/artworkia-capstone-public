﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class AccountModel
{
    [Required]
    [MaxLength(255)]
    public string? Username { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Email { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Fullname { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Bio { get; set; }
    [Required]
    public DateTime? Birthdate;
}
