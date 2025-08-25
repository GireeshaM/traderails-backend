using System;
using System.Collections.Generic;

namespace traderails_backend_dataAccess.Models;

public partial class Organization
{
    public int OrganizationId { get; set; }

    public int? UserId { get; set; }

    public string? OrganizationName { get; set; }

    public string? OrganizationType { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public byte[]? OrganizationLogo { get; set; }

    public bool? TermsAccepted { get; set; }

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

    public virtual ICollection<LegalDetail> LegalDetails { get; set; } = new List<LegalDetail>();

    public virtual User? User { get; set; }
}
