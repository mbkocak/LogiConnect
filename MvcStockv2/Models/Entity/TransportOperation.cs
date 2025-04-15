using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class TransportOperation
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? JobTitle { get; set; }

    public string? Salary { get; set; }

    public int? TransportId { get; set; }

    public virtual Transport? Transport { get; set; }
}
