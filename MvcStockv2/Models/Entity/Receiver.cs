using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Receiver
{
    public int ReceiverFirmId { get; set; }

    public string? ReceiverFirmName { get; set; }

    public string? ReceiverFirmEmail { get; set; }

    public string? ReceiverFirmLocation { get; set; }

    public virtual ICollection<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();

    public virtual ICollection<SalesMarketing> SalesMarketings { get; set; } = new List<SalesMarketing>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
