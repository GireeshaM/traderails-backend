using System;
using System.Collections.Generic;

namespace traderails_backend_dataAccess.Models;

public partial class LegalDetail
{
    public int LegalDetailId { get; set; }

    public int? OrganizationId { get; set; }

    public string? LegalName { get; set; }

    public string? CountryOfIncorporation { get; set; }

    public string? RegisteredAddress { get; set; }

    public string? RegisteredNumber { get; set; }

    public DateOnly? DateOfIncorporation { get; set; }

    public virtual Organization? Organization { get; set; }
}
