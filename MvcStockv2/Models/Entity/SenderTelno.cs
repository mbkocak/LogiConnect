using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class SenderTelno
{
    public string SenderTelNo1 { get; set; } = null!;

    public int? SenderFirmId { get; set; }

    public virtual Sender? SenderFirm { get; set; }
}
