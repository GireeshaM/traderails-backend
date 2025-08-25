using System;
using System.Collections.Generic;

namespace traderails_backend_dataAccess.Models;

public partial class BankAccount
{
    public int BankAccountId { get; set; }

    public int? OrganizationId { get; set; }

    public string? BankName { get; set; }

    public string? AccountNumber { get; set; }

    public string? Ifsccode { get; set; }

    public virtual Organization? Organization { get; set; }
}
