using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Storage
{
    public int StorageId { get; set; }

    public int StorageCapacity { get; set; }

    public int? ProductId { get; set; }

    public string? StorageName { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<StorageLocation> StorageLocations { get; set; } = new List<StorageLocation>();

    public virtual ICollection<SupplyChain> SupplyChains { get; set; } = new List<SupplyChain>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
