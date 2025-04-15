using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class StorageLocation
{
    public string StorageLocation1 { get; set; } = null!;

    public int? StorageId { get; set; }

    public virtual Storage? Storage { get; set; }
}
