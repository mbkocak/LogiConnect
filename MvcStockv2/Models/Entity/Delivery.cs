using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Delivery
{
    public int TransportId { get; set; }

    public int ReceiverFirmId { get; set; }

    public string? DeliveryDate { get; set; }
}
