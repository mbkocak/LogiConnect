using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Transport
{
    public int TransportId { get; set; }

    public string? TransportType { get; set; }

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();

    public virtual ICollection<TransportOperation> TransportOperations { get; set; } = new List<TransportOperation>();
}
