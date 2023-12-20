﻿using Application.Services.Abstractions;
using System.Security.Claims;

namespace WebApi.Services;

public class ClaimService : IClaimService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Guid? GetCurrentUserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor
                                    .HttpContext?
                                    .User?
                                    .FindFirstValue(ClaimTypes.SerialNumber);
            return string.IsNullOrEmpty(userIdClaim) ?
                            null : Guid.Parse(userIdClaim);
        }
    }
    public string GetCurrentUserName
    {
        get
        {
            var userNameClaim = _httpContextAccessor
                                    .HttpContext?
                                    .User?
                                    .FindFirstValue(ClaimTypes.NameIdentifier);
            return string.IsNullOrEmpty(userNameClaim) ?
                            string.Empty : userNameClaim;
        }
    }

    public string GetCurrentRole
    {
        get
        {
            var userRoleClaim = _httpContextAccessor
                                    .HttpContext?
                                    .User?
                                    .FindFirstValue(ClaimTypes.Role);
            return string.IsNullOrEmpty(userRoleClaim) ?
                            string.Empty : userRoleClaim;
        }
    }    
}
