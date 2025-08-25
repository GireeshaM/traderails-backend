using System;
using System.Collections.Generic;

namespace traderails_backend_dataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public int? RoleId { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Mfaotp { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PhoneVerificationMethod { get; set; }

    public string? PhoneOtp { get; set; }

    public bool? IsPhoneVerified { get; set; }

    public bool? IsEmailVerified { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual Role? Role { get; set; }
}
