using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Sender
{
    public int SenderFirmId { get; set; }

    public string? SenderFirmName { get; set; }

    public string? SenderFirmEmail { get; set; }

    public string? SenderFirmLocation { get; set; }

    public virtual ICollection<SenderTelno> SenderTelnos { get; set; } = new List<SenderTelno>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
