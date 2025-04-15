using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class SupplyChain
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? JobTitle { get; set; }

    public string? Salary { get; set; }

    public int? StorageId { get; set; }

    public virtual Storage? Storage { get; set; }
}
