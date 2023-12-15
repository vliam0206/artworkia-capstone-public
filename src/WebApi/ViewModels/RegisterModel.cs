﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels;

public class RegisterModel
{
    [MaxLength(150)]
    [Required]
    public string Username { get; set; } = default!;
    [MaxLength(255)]
    [Required]
    public string Password { get; set; } = default!; // remember to hash password before save/check
    [MaxLength(255)]
    [Required]
    public string Email { get; set; } = default!;
    [Required]
    [MaxLength(150)]
    public string Fullname { get; set; } = default!;   
    [Required]
    public DateTime? Birthdate;
}
