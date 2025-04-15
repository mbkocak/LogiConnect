using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductType { get; set; }

    public string? ProductUnit { get; set; }

    public string? ProductSensivity { get; set; }

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
